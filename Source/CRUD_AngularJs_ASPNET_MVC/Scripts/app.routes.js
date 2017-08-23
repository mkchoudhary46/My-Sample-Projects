define(['angularAMD', 'generalConfig', 'pathService'], function (angularAMD, generalConfig, pathService) {
    'use strict';

    return ['$stateProvider', '$httpProvider', '$urlRouterProvider', 'localStorageServiceProvider', 'loggerServiceProvider', function ($stateProvider, $httpProvider, $urlRouterProvider, localStorageServiceProvider, loggerService) {

        $httpProvider.interceptors.push('authInterceptorService');
       // $locationProvider.html5Mode(true).hashPrefix('!');

        localStorageServiceProvider
            .setStorageType('sessionStorage')
            .setStorageCookie(0, '/');

        loggerService.setLogLevel(generalConfig.logLevel);

        $urlRouterProvider.otherwise('/');

        $stateProvider
            .state('app', angularAMD.route({
                'abstract': true,
                templateUrl: pathService.setView('app', 'app'),
                controller: 'AppCtrl',
                controllerUrl: pathService.setController('app', 'app')
            }))
            .state('app.profile', angularAMD.route({
                url: '^/.',
                templateUrl: pathService.setView('profile', 'profile'),
                controllerUrl: pathService.setController('profile', 'profile'),
                controller: 'profileCtrl',
            }));
    }];
});