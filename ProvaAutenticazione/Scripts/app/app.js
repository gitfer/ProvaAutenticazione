var app = angular.module('prova', ['ngCookies', 'pascalprecht.translate'], ['$translateProvider', function($translateProvider) {
    $translateProvider.useUrlLoader('http://localhost:54596/api/language');
    // register german translation table
    //$translateProvider.translations('it', {
    //    'GREETING': 'Hallo Welt!'
    //});
    //// register english translation table
    //$translateProvider.translations('en', {
    //    'GREETING': 'Hello World!'
    //});
    // which language to use?
    $translateProvider.preferredLanguage('it');
}]);

app.controller('myController', function($scope, $translate) {
    $scope.languages = [{ label: 'en' }, { label: 'it' }];
    $scope.selectedLanguage = $scope.languages[1];
    $translate.use($scope.selectedLanguage.label);
    
    $scope.$watch('selectedLanguage', function (oldVal, newVal) {
        if (newVal) {
            console.log($scope.selectedLanguage.label);
            $translate.use($scope.selectedLanguage.label);
        }
    });
})