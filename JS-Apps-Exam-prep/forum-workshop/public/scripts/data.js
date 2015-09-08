var data = (function () {
    var USER_AUTH_KEY_HEADER,
        USERNAME,
        storage = localStorage;
    //---------------POSTS--------------------
    function getAllPosts(query) {
        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: 'api/threads',
                type: 'GET',
                data:query,
                contentType: 'application/json',
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    alert('error while loading all posts: ' + err.responseText);
                    reject();
                }
            });
        })

        return promise;
    }

    function getPostById(id) {
        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: 'api/threads/'+id,
                type: 'GET',
                contentType: 'application/json',
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    alert('error while loading all posts: ' + err.responseText);
                    reject();
                }
            });
        })

        return promise;
    }

    function addPost(post) {
        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: 'api/threads',
                type: 'POST',
                data:JSON.stringify(post),
                headers:{
                    'x-authkey':storage.getItem(USERNAME)
                },
                contentType: 'application/json',
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    alert('error while creating new post: ' + err.responseText);
                    reject();
                }
            });
        })

        return promise;
    }

    function addMessageToPostWithId(id,post) {
        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: 'api/threads/'+id+'/messages',
                type: 'POST',
                data:JSON.stringify(post),
                headers:{
                    'x-authkey':storage.getItem(USERNAME)
                },
                contentType: 'application/json',
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    alert('error while creating new post: ' + err.responseText);
                    reject();
                },
                beforeSend:function(){
                }
            });
        })

        return promise;
    }


    //---------------USERS--------------------
    function registerUser(user) {
        var userToSend = {
            username: user.username,
            passHash: CryptoJS.SHA1(user.password).toString()
        };

        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: 'api/users',
                type: 'POST',
                data: JSON.stringify(userToSend),
                contentType: 'application/json',
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    alert('Error occured when registering user: ' + err.responseText);
                }
            });
        })

        return promise;
    }

    function loginUser(user) {
        var userToSend = {
            username: user.username,
            passHash: CryptoJS.SHA1(user.password).toString()
        };

        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: 'api/auth',
                type: 'PUT',
                data: JSON.stringify(userToSend),
                contentType: 'application/json',
                success: function (data) {
                    storage.setItem(USERNAME,data.username);
                    storage.setItem(USER_AUTH_KEY_HEADER,data.authKey);
                    resolve();
                },
                error: function (err) {
                    alert('Error occured when logging user: ' + err.responseText);
                }
            });
        })

        return promise;
    }

    function getCurrentUser() {
        var promise = new Promise(function (resolve, reject) {
            if (storage.getItem(USER_AUTH_KEY_HEADER) === null) {
                resolve(null);

            }
            else {
                resolve(storage.getItem(USERNAME));
            }
        })

        return promise;
    }

    function logoutUser() {
        var promise=new Promise(function(resolve,reject){
            storage.removeItem(USER_AUTH_KEY_HEADER);
            storage.removeItem(USERNAME);
            resolve();
        })

        return promise;
    }

    function getAllUsers() {

    }

    return {
        posts: {
            getAll: getAllPosts,
            getById: getPostById,
            addPost: addPost,
            addMessageToPost: addMessageToPostWithId
        },
        users: {
            register: registerUser,
            login: loginUser,
            getAll: getAllUsers,
            getCurrent: getCurrentUser,
            logout: logoutUser
        }
    }
}());
