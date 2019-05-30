'use stric';


var app = angular.module('App', ['blockUI', 'ui.grid', 'ui.grid.pagination', 'ui.grid.autoResize', 'ui.grid.resizeColumns', 'ui.grid.exporter', 'ui.grid.selection', 'ui.grid.grouping']);
var Obj;
var token = "";
var path = "";


//app.provider('todoListService', function () {

//    var todoList = [];

//    return {
//        loadDefaults: function (newList) {
//            todoList = newList;
//        },
//        $get: function ()
//        {
//            function GetIds(todo) {
//                return todo;
//            }
         
//            return {
//                GetIds: GetIds,               
//            };
//        },
//        $put: function () {
//            function GetIdsUpdate(todo) {
//                return todo;
//            }

//            return {
//                GetIds: GetIds,
//            };
//        },
//       };
//});



//app.config(function (todoListServiceProvider) {
//    todoListServiceProvider.loadDefaults([1, 2, 3]);   
//});


// servico
app.service('todoListService', function () {        
    
    path = window.location.origin;
    return {

        $get: function (path) {
            var returns = path
            return "$get";
        },
        $put: function (path) {
            var returns = path
            return "$put";
        },
        $delete: function (path) {
            var returns = path
            return "$delete";
        },
        $post: function (path) {
            var returns = path
            return "$post";
        }
    }   

})



app.controller("CtrlLogon", ['$scope', '$http', '$location', '$window', '$timeout', 'blockUI', 'uiGridConstants', 'uiGridGroupingConstants', '$interval', 'todoListService',
function ($scope, $http, $location, $window, $timeout, blockUI, uiGridConstants, uiGridGroupingConstants, $interval, todoListService) {
    
    Obj = $scope;
    $scope.todoList = todoListService.todoList;
    var a = todoListService.$get($location.$$absUrl);
    todoListService.$post($location.$$absUrl);
   
    var Acess = {
        User: "",
        Password:""
    }

    $scope.Login = function () {

        var model = $scope.Logon;

        if(model.User == "a" && model.Password == "a")
        {
            var url = $location.$$absUrl;
            //var a = todoListService.$post().addTodo();
            blockUI.start("...CARREGANDO CONFIGURAÇÕES PERSONALIZADAS...");
            $window.location.href = '/Home/Index';

        }
    }

}]);