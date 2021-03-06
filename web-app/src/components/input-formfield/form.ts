import { Router } from 'aurelia-router';
import { APIRequest } from './../../resources/scripts/api';
import { Data } from './../../resources/scripts/data';
import { Inputs } from './../../resources/scripts/inputs';
import {EventAggregator} from 'aurelia-event-aggregator';
import { inject } from 'aurelia-framework';


@inject(EventAggregator, Router)
export class Form{
  inputs: Inputs;
  ea: EventAggregator
  router: Router

  age: string = '';

  constructor(EventAggregator, router){
    this.ea = EventAggregator;
    this.router = router;

    this.inputs = Data.instance.inputs;
    if(sessionStorage.getItem("saveData")){
      var storage = JSON.parse(sessionStorage.saveData);
      this.age = storage.currentAge
    }

  }


  //storing form data on browser back button

  storeInputFields(){
    sessionStorage.saveData = JSON.stringify({
      "currentAge": this.age
    });
  }
  
  


  submitFormButton() {
    APIRequest.postInputs(this.inputs)
      .then(data => {
        Data.instance = data as Data;
        Data.instance.inputs = this.inputs;
        this.router.navigateToRoute("results");
    });
  }
}






