app.controller("mvcCRUDCtrl", function($scope, crudAJService) {

    $scope.divBook = false;
    $scope.books = [];
    $scope.Id ="";
    $scope.Title = "";
    $scope.Author = "";
    $scope.Publisher = "";
    $scope.Isbn ="";
    function getAllBooks() {
        var getBookData = crudAJService.getBooks();
        getBookData.then(function (books) {
            $scope.books = books.data;
        }, function () {
            alert('Error in getting book records');
        });
    }

    $scope.editBook = function (book) {
        var getBookData = crudAJService.getBook(book.Id);
        getBookData.then(function (book) {
            $scope.book = book.data;
            $scope.Id = book.data.Id;
            $scope.Title = book.data.Title;
            $scope.Author = book.data.Author;
            $scope.Publisher = book.data.Publisher;
            $scope.Isbn = book.data.Isbn;
            $scope.Action = "Update";
            $scope.divBook = true;
        }, function () {
            alert('Error in getting book records');
        });
    }

    $scope.AddUpdateBook = function () {
        var book = {
            Title: $scope.Title,
            Author: $scope.Author,
            Publisher: $scope.Publisher,
            Isbn: $scope.Isbn
        };
        var getBookAction = $scope.Action;

        if (getBookAction === "Update") {
            book.Id = $scope.Id;
            var getBookData = crudAJService.updateBook(book);
            getBookData.then(function (msg) {
                getAllBooks();
                alert(msg.data);
                $scope.divBook = false;
            }, function () {
                alert('Error in updating book record');
            });
        }else {
            var getBookData = crudAJService.AddBook(book);
            getBookData.then(function (msg) {
                getAllBooks();
                alert(msg.data);
                $scope.divBook = false;
            }, function () {
                alert('Error in adding book record');
            });
        }
    }

    $scope.AddBookDiv = function () {
        clearFields();
        $scope.Action = "Add";
        $scope.divBook = true;
    }

    $scope.deleteBook = function (book) {
        var getBookData = crudAJService.DeleteBook(book.Id);
        getBookData.then(function (msg) {
            alert(msg.data);
            getAllBooks();
        }, function () {
            alert('Error in deleting book record');
        });
    }

    function clearFields() {
        $scope.Id = "";
        $scope.Title = "";
        $scope.Author = "";
        $scope.Publisher = "";
        $scope.Isbn = "";
    }
    $scope.Cancel = function () {
        $scope.divBook = false;
    };
    ($scope.init= function() {
       getAllBooks();
    })();
});