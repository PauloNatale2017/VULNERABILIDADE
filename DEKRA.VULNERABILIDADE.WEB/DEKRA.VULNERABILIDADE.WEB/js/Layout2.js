var app = angular.module('App', ['blockUI']);
var Obj;
var token = "";

app.controller("CtrlLayout", ['$scope', '$http', '$location', '$window', 'blockUI', '$timeout',
function ($scope, $http, $location, $window, blockUI, $timeout, nvd3) {

    Obj = $scope;

    var url = window.location.origin;
  
    $scope.LoginForm = function () {

           $window.location.href = url + "/Home/index";       
   
    };

}]);