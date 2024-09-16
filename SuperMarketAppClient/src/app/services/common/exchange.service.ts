import { Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Get_Exchange } from '../../contracts/get-exchange';

@Injectable({
  providedIn: 'root'
})
export class ExchangeService {

  constructor(private httpClientService: HttpClientService) { }

  async getExchange(successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void): Promise<Get_Exchange> {
    const promiseData: Promise<Get_Exchange> = this.httpClientService.get<Get_Exchange>({
      controller: "exchanges",
    }).toPromise();

    promiseData.then(d => successCallBack())
      .catch((errorResponse: HttpErrorResponse) => errorCallBack(errorResponse.message))

    return await promiseData;
  }
}
