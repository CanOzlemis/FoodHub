import { Component, OnInit, ViewChild } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { IGetEarningsHistory } from 'src/app/shared/interfaces';
import { LoadingService } from 'src/app/shared/loading.service';
import { OwnerService } from 'src/app/shared/owner.service';
import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexTitleSubtitle
} from "ng-apexcharts";

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  title: ApexTitleSubtitle;
};

@Component({
  selector: 'app-economics',
  templateUrl: './economics.component.html',
  styleUrls: ['./economics.component.css']
})
export class EconomicsComponent implements OnInit {
  earningHistory: IGetEarningsHistory[];
  dailyData;
  earningsData;
  currentOpen = -1;
  changePercentages = [];

  chartOptions = {
    series: [
      {
        name: "Total orders that day",
        data: []
      },
      {
        name: "Earned that day",
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
        enabled: true,
      },
      dynamicAnimation: {
        enabled: true
      }
    },
    dataLabels: {
      enabled: false
    },
    title: {
      text: "Daily order change"
    },
    xaxis: {
      categories: []
    }
  };


  constructor(
    private _ownerService: OwnerService,
    private _toastr: ToastrService,
    private _loading: LoadingService,
  ) { }

  ngOnInit(): void {
    this.updateEarningHistory();
    this.updateActiveEarnings();

  }

  updateActiveEarnings() {
    this._ownerService.GetEarningsData().subscribe(
      res => {
        this.earningsData = res;
      },
      err => {
        this._toastr.error("Could\'t load earnings data.", "Error", {
          timeOut: 5000
        });
      });
  }

  updateEarningHistory() {
    this._ownerService.GetEarningsHistory().subscribe(
      (res: IGetEarningsHistory[]) => {
        this.earningHistory = res;

        //Empty the array if there is still data from previous call
        this.changePercentages = [];
        for (let i = 0; i < this.earningHistory.length; i++) {
          this.GenerateRatio(i);
        }

      },
      err => {
        this._toastr.error("Could't load earning history.", "Error", {
          timeOut: 5000
        });
      });
  }


  panelOpen(index) {
    this.currentOpen = index;
  }

  buildChart(x) {
    this.dailyData = x;
    let arrayOfDay = [];
    let arrayOfTotal = [];
    let arrayOfValue = [];


    this.dailyData?.forEach(element => {
      arrayOfDay.push(element.Day);
      arrayOfValue.push(element.Value);
      arrayOfTotal.push(element.Total);
    });

    this.chartOptions.series[0].data = arrayOfTotal;
    this.chartOptions.series[1].data = arrayOfValue;
    this.chartOptions.xaxis.categories = arrayOfDay;

  }

  GenerateRatio(index) { //generates ratios based on monthly earning for displaying on the screen
    const ratio = this.earningHistory[index + 1] && this.earningHistory[index + 1].history.Total != null
      ? ((100 * this.earningHistory[index].history.Total) / this.earningHistory[index + 1].history.Total)
      : 0;
    //If the value is lower than previous month display the ratio as -xx% .
    this.changePercentages.push(ratio && ratio !== 0 ? (ratio - 100).toFixed(1) : ratio.toFixed(1));
  }


  arrayEmpty(array: any[]){
    return !Array.isArray(array) || !array.length;
  }

}
