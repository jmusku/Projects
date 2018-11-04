var app = angular.module('myApp', ['ngRoute']);

app.config(['$locationProvider', '$routeProvider', function ($locationProvider, $routeProvider) {
        
    $routeProvider.when('/EmployeeList', {
        templateUrl: '/App/Views/EmployeeList.html',
        controller: 'EmployeeController'
    });
    $routeProvider.when('/AddEmployee', {
        templateUrl: '/App/Views/AddEmployee.html',
        controller: 'EmployeeController'
    });
    $routeProvider.when('/EditEmployee/:empId', {
        templateUrl: '/App/Views/EditEmployee.html',
        controller: 'EmployeeController'
    });
    $routeProvider.when('/DeleteEmployee/:empId', {
        templateUrl: '/App/Views/DeleteEmployee.html',
        controller: 'EmployeeController'
    });
    $routeProvider.otherwise({ redirectTo: '/EmployeeList' });
}]);