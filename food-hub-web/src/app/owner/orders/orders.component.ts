import { Component, ElementRef, EventEmitter, OnDestroy, OnInit, Output, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { OrderDetailsDialogComponent } from 'src/app/Dialogs/order-details-dialog/order-details-dialog.component';
import { IGetOrderDetails, IGetOrders } from 'src/app/shared/interfaces';
import { OwnerService } from 'src/app/shared/owner.service';
import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexTitleSubtitle
} from "ng-apexcharts";
import { MatTableDataSource } from '@angular/material/table';
import { RejectOrderDialogComponent } from 'src/app/Dialogs/reject-order-dialog/reject-order-dialog.component';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  title: ApexTitleSubtitle;
};

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit, OnDestroy {

  Orders: IGetOrders[];
  seriesData = []; //seriesData and SeriesCategory hold the items to store them as array so that it can be displayed in the chart
  SeriesCategory = [];
  dataSource;
  refresher; // Variable to hold the repeater for constandly refreshing the orders
  openChart = false;
  previousOrderAmount = -1; // This will be used to track if there is new orders received between the two API calls
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild('orderSearchFilter') orderSearchFilter:ElementRef;
  @Output() orderCount = new EventEmitter<number>();


  chartOptions = { //This is created so that the chart can render. Later on updateChart() is called to update the graph with data
    series: [
      {
        name: "Order count",
        data: []
      }
    ],
    chart: {
      height: 350,
      type: "area",
      zoom: {
        enabled: false
      },
      toolbar: {
        show: false
      },
      animations: {
        enabled: false,
      },
      dynamicAnimation: {
        enabled: false
      }
    },
    dataLabels: {
      enabled: false
    },
    title: {
      text: "Daily order change"
    },
    xaxis: {
      categories: [],
      labels: {
        show: false
      }
    },
    noData : {
      text: "No Data",
      align: "center",
      verticalAlign: "middle",
      offsetX: 0,
      offsetY: 0
    }
  };


  constructor(
    private _ownerService: OwnerService,
    private _toastr: ToastrService,
    private dialog: MatDialog
  ) {

  }


  ngOnInit(): void {

    this.UpdateOrders(); // The initial call to display the orders

    this._ownerService.GetDailyOrderChartData().subscribe(
      (res: any) => {

        res.forEach(element => { //Need to seperate the tupple into seriesData array and SeriesCategory array
          this.SeriesCategory.push(element.Item1);
          this.seriesData.push(element.Item2);
        });

        this.UpdateChart();

      });

    
    this.refresher = setInterval(() => {
      this.UpdateOrders();
      //this.UpdateChart(); // Refresh only if more orders are detected
    }, 6000); // repeat every 6 seconds
  }

  ngOnDestroy(): void {
    /*
      * This has to be done to stop the loop from continuing none stop. Angular is a single page desing meaning that this page is 
      * never really closed hence we need to stop the interval once we are done with this component.
      */
    clearInterval(this.refresher);
  }

  UpdateChart() {
    this.openChart = true; //Forcing the chart to render after everything is done, Without this the chart is rendered wrong and does not display data
    //Push the data to the chartData which will update the graphics
    this.chartOptions.series[0].data = this.seriesData;
    this.chartOptions.xaxis.categories = this.SeriesCategory;

  }



  UpdateOrders() {
    this._ownerService.GetOrders().subscribe(
      (res: IGetOrders[]) => {
        this.Orders = res;
        this.dataSource = new MatTableDataSource(res);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        this.applyFilter(); //If the user has applied a search filter, when the new values are received, maintain the filter result
        this.orderCount.emit(this.Orders.length);
        if(this.previousOrderAmount != -1 && this.Orders.length != this.previousOrderAmount) {
          this._toastr.info('You have new orders!', 'New orders');
        }
        this.previousOrderAmount = this.Orders.length;

      },
      err => {
        this._toastr.error('Couldnt load the orders!', 'Error', {
          timeOut: 5000
        });
        console.log(err);
      }
    )
  }

  openOrderDetailsDialog(data: IGetOrders) {
    const dialogRef = this.dialog.open(OrderDetailsDialogComponent, {
      data: {
        model: data
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        switch (result) {
          case 'Accept':
            this._ownerService.AcceptOrder(data.OrderId).subscribe(
              res => { this._toastr.info('Order accepted', 'Accepted'); this.UpdateOrders(); },
              err => { this._toastr.error('Couldn\'t accept order', 'Error', { timeOut: 5000 }); console.log(err) }
            );
            break;
          case 'Complete':
            this._ownerService.CompleteOrder(data.OrderId).subscribe(
              //Update the previous order amount after completing since it will register the number difference as new order when it is not
              res => { this._toastr.info('Order completed', 'Completed'); this.previousOrderAmount -= this.previousOrderAmount > 0 ? 1 : 0; this.UpdateOrders(); },
              err => { this._toastr.error('Couldn\'t complete order', 'Error', { timeOut: 5000 }); console.log(err) }
            );
            break;
          case 'Reject':
            let message = '';
            const rejectResponseDialog = this.dialog.open(RejectOrderDialogComponent);
            rejectResponseDialog.afterClosed().subscribe(res => {
              if (res === false || res === undefined) { // If the dialog was closed rather than rejected
              } else {
                message = res ? res : 'Restaurant has rejected your order';
                this._ownerService.RejectOrder({ OrderId: data.OrderId, Note: message }).subscribe(
                  //Update the previous order amount after completing since it will register the number difference as new order when it is not
                  res => { this._toastr.info('Order rejected', 'Rejected'); this.previousOrderAmount -= this.previousOrderAmount > 0 ? 1 : 0; this.UpdateOrders(); },
                  err => { this._toastr.error(err?.error?.message ? err?.error?.message : 'Couldn\'t reject order', 'Error', { timeOut: 5000 }); console.log(err) }
                );
              }

            });
            break;
          default:
            break;
        }
      }else {
        this.UpdateOrders();
      }
      
    });
  }

  currentStatusCount(status: string) {
    let count = 0;
    if (this.Orders) {
      this.Orders.forEach(element => {
        if (element.Status == status) {
          count++;
        }
      });
    }

    return count;
  }

  applyFilter(event?: Event) {
    if(event){
      const filterValue = (event.target as HTMLInputElement).value;
      this.dataSource.filter = filterValue.trim().toLowerCase();
      return;
    }
    this.dataSource.filter = this.orderSearchFilter.nativeElement.value;
    if (event && this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }

  }


}
