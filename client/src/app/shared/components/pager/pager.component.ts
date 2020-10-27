import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.scss']
})
export class PagerComponent implements OnInit {

  @Input() count: number;
  @Input() pageSize: number;
  @Input() pageNumber: number;
  @Output() pageChanged = new EventEmitter<number>();

  constructor() { }

  ngOnInit() {
  }

  onPagerChanged(event: any) {
    this.pageChanged.emit(event.page);
  }
}
