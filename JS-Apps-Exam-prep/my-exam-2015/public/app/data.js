var data = (function() {
    const LOCAL_STORAGE_USERNAME_KEY = 'signed-in-user-username',
        LOCAL_STORAGE_AUTHKEY_KEY = 'signed-in-user-auth-key';

    /* Users */

    function register(user) {
        var reqUser = {
            //@@@@@@@@@@@@@@@@@@@@@  Check user.username and user.password
            username: user.username,
            authCode: CryptoJS.SHA1(user.username + user.password).toString()
        };
//@@@@@@@@@@@@@@@@@@@@@ Change url and type of request(post,put)
        return jsonRequester.post('/user', {
            data: reqUser
        })
            .then(function(respond) {
                //@@@@@@@@@@@@@@@@@@@@@ Check and Change respond type
                return {
                    respond: respond
                };
            },function(error){
                return error;
            });
    }


    function signIn(user) {
        var reqUser = {
            //@@@@@@@@@@@@@@@@@@@@@ Check and Change username and authCode. Check user.username and user.password
            username: user.username,
            authCode: CryptoJS.SHA1(user.username + user.password).toString()
        };

        var options = {
            data: reqUser
        };
//@@@@@@@@@@@@@@@@@@@@@ Change url and type of request(post,put)
        return jsonRequester.post('/auth', options)
            .then(function(respond){
                var user = respond;
                //@@@@@@@@@@@@@@@@@@@@@ Check and Change username and sessionKey
                localStorage.setItem(LOCAL_STORAGE_USERNAME_KEY, user.username);
                localStorage.setItem(LOCAL_STORAGE_AUTHKEY_KEY, user.sessionKey);

                return user;
            });
    }

    function signOut() {
        //@@@@@@@@@@@@@@@@@@@@@ Check and Change x-sessionkey
        var reqHeaders = {
            'x-sessionkey': localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
        };
        var options = {
            headers: reqHeaders
        };
//@@@@@@@@@@@@@@@@@@@@@ Change url and type of request(post,put)
        return jsonRequester.put('/user', options)
            .then(function(respond) {
                var isSuccessful = respond;
                localStorage.removeItem(LOCAL_STORAGE_USERNAME_KEY);
                localStorage.removeItem(LOCAL_STORAGE_AUTHKEY_KEY);
                return isSuccessful;
            });
    }

    function hasUser() {
        return !!localStorage.getItem(LOCAL_STORAGE_USERNAME_KEY) &&
            !!localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY);
    }

    return {
        users: {
            signIn:signIn,
            signOut:signOut,
            register:register,
            hasUser:hasUser,
        }
    };
}());

