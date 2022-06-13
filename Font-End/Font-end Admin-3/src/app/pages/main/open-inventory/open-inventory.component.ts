import { Component, Injector, OnInit } from '@angular/core';
import { FormBuilder, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseComponent } from 'src/app/core/base-component';
import { vOpenInventory } from 'src/app/shared/models/OpenInventory';
import { Permision } from 'src/app/shared/models/Permision';

@Component({
  selector: 'app-open-inventory',
  templateUrl: './open-inventory.component.html',
  styleUrls: ['./open-inventory.component.css']
})
export class OpenInventoryComponent extends BaseComponent implements OnInit {

  public OpenInventorys: any;
  Products: any;
  product: any;
  _selectedPermision: any;
  _selectedFunction: any;
  public Functions: any;
  public permision: Permision;
  public page = 1;
  public pageSize = 10;
  public totalItems: any;
  public formsearch: any;
  public doneSetupForm: any;
  public showUpdateModal: any;
  public formdata: any;
  submitted = false;
  public isCreate: boolean;
  open: vOpenInventory=new vOpenInventory();;
  constructor(private fb: FormBuilder, injector: Injector, private route: ActivatedRoute, private router: Router) {
    super(injector);
  }
  ngOnInit(): void {
    this.search();
    setTimeout(() => {
      this.loadScripts();
    });
    //  this._api.get('/api/NhomSanPham/get-all').takeUntil(this.unsubscribe).subscribe(res => {
    //    this.productsGroup = res;
    //  }); 
  }
  productsGroup: any;
  amount: any;
  search() {
    debugger;
    this._api.get('/api/vOpenInventory/get-all').takeUntil(this.unsubscribe).subscribe(res => {
      this.OpenInventorys = res;

    });
    this._api.get(`/api/SanPham/search-name`).takeUntil(this.unsubscribe).subscribe(res => {
      this.Products = res;
    });

  }

  displayAdd: boolean = false;
  showAdd() {
    this.displayAdd = true;
  }
  AddNew(form) {
    form.value.ProducdId = this.product.maSanPham;
    form.value.unit =this.open.Unit;
    debugger;
    console.log(form.value);
    this._api.post('/api/vOpenInventory/insert', form.value).takeUntil(this.unsubscribe).subscribe(res => {
      alert("Thêm thành công");
      this.search();
    }
      , err => { console.log(err); });
  }

  showEdit(id: any) {
    this.router.navigate(['manage-acc-doc-detail', id]);
  }

 
  onChangeProduct(form) {
    this.open.UnitCost = this.product.giaBan;
    this.open.Unit = "cái";
    this.open.Amount = this.product.UnitCost * this.open.Quantity;
  }

  onChangeQuantity(form) {
    debugger;
    this.open.Amount = form.value.unitCost * form.value.quantity;
  }
}


