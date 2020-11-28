app.service("APIService", function ($http) {
    var baseUrl = 'http://localhost:50129/';
    this.getPosts = function () {
        var url = baseUrl+'api/Post';
        return $http.get(url).then(function (response) {
            return response.data;
        });
    }
    this.getPostsByKeyward = function (keyword) {
        var url = baseUrl + 'api/PostbyKeyward';
        return $http.get(url + '?keywod=' + keyword).then(function (response) {
            return response.data;
        });
    }
    
});