import { Component, OnInit } from '@angular/core';
import {Game } from '../models';
import { GamesService } from '../services/games.service';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';


@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.css'],
})
export class GamesComponent implements OnInit {
  data: Game[] = [];
  displayedColumns: string[] = ['GameId', 'isbn', 'title'];
  isLoadingResults = true;

  getGames(): void {
    this.GamesService.getGames().subscribe(
      (Games) => {
        this.data = Games;
        console.log(this.data);
        this.isLoadingResults = false;
      },
      (err) => {
        console.log(err);
        this.isLoadingResults = false;
      }
    );
  }

  constructor(
    private GamesService: GamesService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {

    this.getGames();


  }
}
