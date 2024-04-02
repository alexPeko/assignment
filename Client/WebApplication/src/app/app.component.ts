import { Component, OnInit } from '@angular/core';
import { EntityService } from './entity.service';
import { FormControl, FormGroup } from '@angular/forms';
import { Entity } from './models/entity';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  entityForm!: FormGroup;
  entities: Entity[] = [];

  constructor(public entityService: EntityService) {}

  ngOnInit() {
    this.entityForm = new FormGroup({
      name: new FormControl('')
    });
    this.getEntities();
  }

  onSubmit() {
    this.entityService.addEntity(this.entityForm.get('name')!.value).subscribe(() => {
      this.getEntities();
    });
  }

  deleteEntity(entity: Entity) {
    this.entityService.deleteEntity(entity.id).subscribe(() => {
      this.getEntities();
    });
  }

  getEntities() {
    this.entityService.getEntities().subscribe(entities => {
      this.entities = entities;
    })
  }
}
