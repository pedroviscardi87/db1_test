var myApp = angular.module('myApp', ['ui.bootstrap']);
myApp.controller('_LayoutController', ['$scope', '$http', '$templateCache', function ($scope, $http, $templateCache) {
    //part 2
    $scope.company = 'DB1 Global Software';
    $scope.model_user = null;
    $scope.users = null;
    $scope.repository = null;
    $scope.view = function (login) {
        $('.loading').show();
        $http({
            method: 'GET',
            url: 'https://api.github.com/users/' + login,
            headers: { 'Content-Type': 'application/json' }
        }).then(function successCallback(response) {
            $scope.model_user = response.data;
            $scope.get_repository($scope.model_user.login);
            $('#modal-user').modal('show');
        }, function errorCallback(response) {
            $scope.model_user = null;
            $('.loading').hide();
        });

    };
    $scope.get_repository = function (login) {
        $('.loading').show();
        $http({
            method: 'GET',
            url: 'https://api.github.com/users/' + login + '/repos',
            headers: { 'Content-Type': 'application/json' }
        }).then(function successCallback(response) {
            $scope.repository = response.data;
            $('.loading').hide();
        }, function errorCallback(response) {
            $scope.repository = null;
            $('.loading').hide();
        });
    };
    $scope.get_users = function () {
        $('.loading').show();
        $http({
            method: 'GET',
            url: 'https://api.github.com/users',
            headers: { 'Content-Type': 'application/json' }
        }).then(function successCallback(response) {
            $scope.users = response.data;
            $('.loading').hide();
        }, function errorCallback(response) {
            $scope.users = null;
            $('.loading').hide();
        });
    };
    //part 3
    $scope.technologies = null;
    $scope.vacancies = null;
    $scope.candidates = null;
    $scope.model_candidate = null;
    $scope.delete = function (id) {
        swal({
            title: 'Tem certeza?',
            text: "Você não poderá reverter isso!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sim'
        }).then(function () {
            $('.loading').show();
            $http({
                method: 'POST',
                url: '/Home/Delete',
                data: { id: id },
                headers: { 'Content-Type': 'application/json' }
            }).then(function successCallback(response) {
                swal('Informação', response.data.message, 'success');
                window.location.reload();
            }, function errorCallback(response) {
                swal('Oops...', 'Houve um problema na operação!', 'error');
                $('.loading').hide();
            });
        })
    };
    $scope.edit = function (candidate) {
        $scope.model_candidate = candidate;
    };
    $scope.savechanges = function () {
        //vacancy
        if ($scope.model_candidate.vacancy == null) {
            swal('Oops...', 'Selecione a vaga que o candidato deseja preencher!', 'error');
            return;
        }
        //technologies
        var technologies = [];
        $('input[name="technologies"]:checked').each(function () { technologies.push({ id: parseInt($(this).attr('data-id')), name: $(this).attr('data-name') }) });
        if (technologies.length == 0) {
            swal('Oops...', 'Selecione as tecnologias que o candidato atua!', 'error');
            return;
        } else {
            $scope.model_candidate.technologies = technologies;
        }
        //post
        $('.loading').show();
        $http({
            method: 'POST',
            url: '/Home/SaveChanges',
            data: { candidate: $scope.model_candidate },
            headers: { 'Content-Type': 'application/json' }
        }).then(function successCallback(response) {
            if (response.data.success) 
                window.location.reload();
            else
                swal('Oops...', 'Houve um problema na operação!', 'error');            
        }, function errorCallback(response) {
            swal('Oops...', 'Houve um problema na operação!', 'error');
            $('.loading').hide();
        });
    };
}]);