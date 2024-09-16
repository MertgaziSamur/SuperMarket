import { Injectable } from '@angular/core';
import { HttpClientService } from '../http-client.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Create_Market } from '../../../contracts/markets/create-market';
import { List_Market } from '../../../contracts/markets/list-market';
import { Update_Market } from '../../../contracts/markets/update-market';
import { List_Rayon } from '../../../contracts/rayons/list-rayon';

@Injectable({
  providedIn: 'root'
})
export class MarketsService {

  constructor(private httpClientService: HttpClientService) { }

  createMarket(market: Create_Market, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void) {
    this.httpClientService.post({
      controller: "markets"
    }, market)
      .subscribe(result => {
        successCallBack();
      }, (errorResponse: HttpErrorResponse) => {
        const _error: Array<{ key: string, value: Array<string> }> = errorResponse.error;
        let message = "";
        _error.forEach((v, index) => {
          v.value.forEach((_v, _index) => {
            message += `${_v}<br>`;
          });
        });
        errorCallBack(message);
      });
  }

  async listMarket(successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void): Promise<List_Market[]> {
    const promiseData: Promise<List_Market[]> = this.httpClientService.get<List_Market[]>({
      controller: "markets",
    }).toPromise();

    promiseData.then(d => successCallBack())
      .catch((errorResponse: HttpErrorResponse) => errorCallBack(errorResponse.message))

    return await promiseData;
  }

  async deleteMarket(id: number, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void) {
    this.httpClientService.delete<any>({
      controller: "markets"
    }, id.toString()).subscribe(result => {
      successCallBack();
    }, (errorResponse: HttpErrorResponse) => {
      const _error: Array<{ key: string, value: Array<string> }> = errorResponse.error;
      let message = "";
      _error.forEach((v, index) => {
        v.value.forEach((_v, _index) => {
          message += `${_v}<br>`;
        });
      });
      errorCallBack(message);
    });
  }

  updateMarket(market: Update_Market, id: number, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void) {
    this.httpClientService.put({
      controller: "markets",
      action: id.toString()
    }, market)
      .subscribe(result => {
        successCallBack();
      }, (errorResponse: HttpErrorResponse) => {
        const _error: Array<{ key: string, value: Array<string> }> = errorResponse.error;
        let message = "";
        _error.forEach((v, index) => {
          v.value.forEach((_v, _index) => {
            message += `${_v}<br>`;
          });
        });
        errorCallBack(message);
      });
  }
  async getMarketRayons(marketId: number): Promise<List_Rayon[]> {
    const promiseData: Promise<List_Rayon[]> = this.httpClientService.get<List_Rayon[]>({
      controller: "markets",
      action: `GetMarketRayons/${marketId}`
    }).toPromise();

    return await promiseData;
  }
}
