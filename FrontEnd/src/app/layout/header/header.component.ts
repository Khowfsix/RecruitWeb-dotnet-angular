import {Component} from '@angular/core';
import {MatIconModule} from '@angular/material/icon';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field'
import {MatSelectModule} from '@angular/material/select';
@Component({
  selector: 'app-header',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatIconModule, MatSelectModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {

}
