import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../lib/authentication.service';

@Component({
  selector: 'app-file-not-found',
  templateUrl: './file-not-found.component.html',
  styleUrls: ['./file-not-found.component.css']
})
export class FileNotFoundComponent implements OnInit {
  constructor(private authenticationService: AuthenticationService,private router: Router) { }
  ngOnInit(): void {
    const user = this.authenticationService.userValue;
    if(user) { 
      this.router.navigate(['/not-found']);
    } else { 
      this.router.navigate(['/login']);
    }
  } 
}
