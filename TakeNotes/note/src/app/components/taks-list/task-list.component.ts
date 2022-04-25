import { Component, OnInit } from '@angular/core';
import {Task} from '../../interfaces/task';

@Component({
  selector: 'task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.less']
})
export class taskListComponent implements OnInit {
    tasks : Task[];
    taskTitle: string;
    idForTasks : number;
    completed : boolean;

  constructor() { }

  ngOnInit() {
    
    this.idForTasks = 2;
    this.taskTitle = '';
    this.tasks = [
    {
      'id' : 1,
      'title' : 'Finsh angular screenshot',
      'completed' : false,
      'editing' : false
    },

  ];

}

  addTask(): void{
    if(this.taskTitle.trim().length == 0 ){
      return;
    }

    this.tasks.push({
      id: this.idForTasks,
      title: this.taskTitle,
      completed:false,
      editing:false
    })

    this.taskTitle = '';
    this.idForTasks++;

  }

  deleteTask(id:number):void{
    this.tasks = this.tasks.filter(task => task.id !==id); 
  }

  remaining(): number {
    return this.tasks.filter(task => !task.completed).length;
  }

  done(): number {
    return this.tasks.filter(task => task.completed).length;
  }

}
