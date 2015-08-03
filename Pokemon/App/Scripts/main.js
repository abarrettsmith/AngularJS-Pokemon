var app = angular.module("app", []);
app.factory("Pokemons", function () {
    return [];
});
app.controller("HomeController", function ($scope, Pokemons, $http) {
    $scope.pokemons = Pokemons;
    $scope.addPokemon = function (pokemon) {
        $http.post("/api/Pokemon", pokemon)
            .success(function () {
                $scope.getAllPokemon();
                pokemon.name = "";
                pokemon.type = "";
            })
            .error(function () {
                console.log();
            });
    };
    $scope.savePokemon = function (pokemon) {
        $http.put("/api/Pokemon", pokemon)
            .success(function (data, status) {
                //$scope.getAllPokemon();
            })
            .error(function () {
                $scope.getAllPokemon();
            })
    };
    $scope.deletePokemon = function (pokemon) {
        $http.delete("/api/Pokemon/"+pokemon.Id)
            .success(function () {
                Pokemons.splice(Pokemons.indexOf(pokemon), 1);
            })
            .error(function (data, status) {
                console.log(status);
            })
    };
    $scope.getAllPokemon = function () {
        $http.get("/api/Pokemon")
            .success(function (data, status) {
                while (Pokemons.length) {
                    Pokemons.pop();
                }
                for (var x in data) {
                    Pokemons.push(data[x]);
                }
            })
            .error(function (data, status) { console.log(status); });
    };
    $scope.getAllPokemon();
});