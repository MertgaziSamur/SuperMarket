import { Injectable } from '@angular/core';
import { HttpClientService } from '../http-client.service';
import { Create_Rayon } from '../../../contracts/rayons/create-rayon';
import { HttpErrorResponse } from '@angular/common/http';
import { List_Rayon } from '../../../contracts/rayons/list-rayon';
import { Update_Rayon } from '../../../contracts/rayons/update-rayon';

@Injectable({
  providedIn: 'root'
})
export class RayonsService {

  constructor(private httpClientService: HttpClientService) { }

  createRayon(rayon: Create_Rayon, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void) {
    this.httpClientService.post({
      controller: "rayons"
    }, rayon)
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

  async listRayon(successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void): Promise<List_Rayon[]> {
    const promiseData: Promise<List_Rayon[]> = this.httpClientService.get<List_Rayon[]>({
      controller: "rayons",
    }).toPromise();

    promiseData.then(d => successCallBack())
      .catch((errorResponse: HttpErrorResponse) => errorCallBack(errorResponse.message))

    return await promiseData;
  }

  async deleteRayon(id: number, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void) {
    this.httpClientService.delete<any>({
      controller: "rayons"
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

  updateRayon(rayon: Update_Rayon, id: number, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void) {
    this.httpClientService.put({
      controller: "rayons",
      action: id.toString()
    }, rayon)
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
}
