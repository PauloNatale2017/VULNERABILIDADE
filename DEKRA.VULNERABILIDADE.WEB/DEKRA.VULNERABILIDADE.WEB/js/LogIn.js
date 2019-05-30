
var app = angular.module('App', ['blockUI']);
var Obj;
var token = "";


app.controller("CtrlLogin", ['$scope', '$http', '$location', '$window', 'blockUI', '$timeout',
function ($scope, $http, $location, $window, blockUI, $timeout, nvd3) {

    $scope.STATUS = "ONLINE";
    $scope.MENSAGEM = "DEKRA T.I";
    $scope.GmudTipe = ["LIBERAÇÃO EMERGENCIAL", "LIBELRAÇÃO"];
    $scope.NUMEROGMUD = ["ATUAL 1461", "1459", "1458"];

    //blockUI.start("...CARREGANDO CONFIGURAÇÕES PERSONALIZADAS...");

}]);