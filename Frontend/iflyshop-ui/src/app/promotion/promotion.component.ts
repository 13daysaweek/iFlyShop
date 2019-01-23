import { Component, OnInit } from '@angular/core';

import { MonitoringService } from '../../services/monitoring.service';
import { PromotionService } from '../../services/promotion.service';
import { Promotion } from '../../models/promotion';

@Component({
  selector: 'app-promotion',
  templateUrl: './promotion.component.html',
  styleUrls: ['./promotion.component.css']
})
export class PromotionComponent implements OnInit {

  promos: Promotion[];

  getPromotions(): void {
    try {
      this.promotionService.getPromotions()
      .subscribe(_ => this.promos = _);
    } catch (e) {
      this.monitoringService.logException(e);
    }
  }

  constructor(private monitoringService: MonitoringService,
    private promotionService: PromotionService) { }

  ngOnInit() {
    this.getPromotions();
  }
}
