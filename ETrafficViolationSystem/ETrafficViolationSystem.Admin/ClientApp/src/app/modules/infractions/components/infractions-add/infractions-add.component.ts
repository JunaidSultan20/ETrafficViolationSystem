import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Infraction} from "../../models/infraction";
import {InfractionsService} from "../../services/infractions.service";
import {StatusCode} from "../../../shared/enums/statusCode";
import {ToastrService} from "ngx-toastr";
import {NgxSpinnerService} from "ngx-spinner";

@Component({
  selector: 'app-infractions-add',
  templateUrl: './infractions-add.component.html',
  styleUrls: ['./infractions-add.component.scss']
})
export class InfractionsAddComponent implements OnInit {
  infractionsModel: Infraction;
  infractionsFormGroup: FormGroup;

  constructor(private infractionsService: InfractionsService, private notification: ToastrService,
              private spinner: NgxSpinnerService) {
    this.infractionsFormGroup = this.createFormGroup();
    this.infractionsModel = new Infraction();
  }

  ngOnInit(): void {
  }

  createFormGroup(): FormGroup {
    return new FormGroup({
      description: new FormControl('', [Validators.required]),
      penalty: new FormControl('', [Validators.required, Validators.minLength(1),
        Validators.maxLength(10)]),
      points: new FormControl('', [Validators.required, Validators.minLength(100),
        Validators.maxLength(1000)])
    });
  }

  get getControls() {
    return this.infractionsFormGroup.controls;
  }

  onSubmit(): void {
    if (this.infractionsFormGroup.valid) {
      this.spinner.show();
      this.infractionsModel.description = this.infractionsFormGroup.controls.description.value;
      this.infractionsModel.penalty = this.infractionsFormGroup.controls.penalty.value;
      this.infractionsModel.points = this.infractionsFormGroup.controls.points.value;
      this.infractionsService.addInfraction(this.infractionsModel).subscribe({
        next: response => {
          if (response.statusCode == StatusCode.Created && response.isSuccessful) {
            this.notification.success('Record added successfully with Id: ' + response.result.infractionId);
            this.spinner.hide();
          }
        }
      })
    }
    console.log(this.infractionsFormGroup);
  }

  reset(): void {
    this.infractionsFormGroup.reset();
  }
}
