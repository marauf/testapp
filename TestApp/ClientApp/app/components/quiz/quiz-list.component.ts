import { Component, Inject } from "@angular/core";
//import { Http, HttpModule } from "@angular/http";
import { HttpClient } from "@angular/common/http"; 



// templateUrl - could be any file name ... 
@Component({
    selector: "quiz-list",
    templateUrl: './quiz-list.component.html',
    styleUrls: ['./quiz-list.component.css']
})

export class QuizListComponent {
    title: string;
    selectedQuiz: Quiz;
    quizzes: Quiz[];


    // DI 
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.title = "Latest Quizzes";
        var url = baseUrl + "api/quiz/Latest/";
        //this.http.get(url).subscribe(result => { this.quizzes = result; }, error => console.error(error));

        /*
         *  ... get - issues standard HTTP request to QuizController to fetch array of quizzes
         *  ... subscribe - instantiates Observable object, executes 2 diff actions after result / error
         *  ... done asynchronously (sep )
         */

        this.http.get<Quiz[]>(url).subscribe(result => { this.quizzes = result; }, error => console.error(error));
    }

    onSelect(quiz: Quiz) {
        this.selectedQuiz = quiz;
        console.log("quiz with Id "
            + this.selectedQuiz.Id
            + " has been selected.");
    }
} 