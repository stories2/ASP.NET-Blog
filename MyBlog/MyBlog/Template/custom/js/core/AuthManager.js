function AuthManager(firebase)
{
    PrintLogMessage("AuthManager", "AuthManager", "init", LOG_LEVEL_INFO)
    this.firebase = firebase
}

AuthManager.prototype.SignUp = function ()
{
    PrintLogMessage("AuthManager", "SignUp", "start google sign up", LOG_LEVEL_INFO)
}

AuthManager.prototype.GenerateToken = function (callbackFunc) {
    firebaseAuth = this.firebase.auth()
    currentUser = firebaseAuth.currentUser
    if (currentUser) {
        PrintLogMessage("AuthManager", "GenerateToken", "user info accepted", LOG_LEVEL_INFO)
        currentUser.getIdToken(/* forceRefresh */ true).then(function (idToken) {
            // Send token to your backend via HTTPS
            // ...
            PrintLogMessage("AuthManager", "GenerateToken", "token generated", LOG_LEVEL_INFO);

            if (callbackFunc !== undefined) {
                callbackFunc(idToken)
            }
        }).catch(function (error) {
            // Handle error
            PrintLogMessage("AuthManager", "GenerateToken", "failed to get token: " + error, LOG_LEVEL_ERROR);
        });
    }
    else {
        PrintLogMessage("AuthManager", "GenerateToken", "user info not accepted", LOG_LEVEL_WARN)
    }
}

AuthManager.prototype.SignIn = function (callbackFunc)
{
    PrintLogMessage("AuthManager", "SignIn", "start google sign in", LOG_LEVEL_INFO)

    provider = new this.firebase.auth.GoogleAuthProvider();

    firebaseAuth = this.firebase.auth()
    firebaseAuth.signInWithPopup(provider)
        .then(function (result)
        {
            PrintLogMessage("AuthManager", "SignIn", "sign in successfully user: " + JSON.stringify(result.user) + " token: " + result.credential.accessToken, LOG_LEVEL_DEBUG)
            if (callbackFunc !== undefined) {
                callbackFunc()
            }
        })
        .catch(function (error)
        {
            PrintLogMessage("AuthManager", "SignIn", "error while sign in code: " + error.code + " msg: " + error.message + " email: " + error.email, LOG_LEVEL_ERROR)
        })
}

AuthManager.prototype.CurrentAuthStatus = function(signInCallback, notSignedInCallback)
{
    PrintLogMessage("AuthManager", "CurrentAuthStatus", "set auth status change listener", LOG_LEVEL_INFO)

    this.firebase.auth().onAuthStateChanged(function(currentUser)
    {
        if (currentUser)
        {
            SetSignedInUserProfile(currentUser.displayName, currentUser.email, currentUser.photoURL)
            ShowOrHideSignedInUserProfile(SHOW_ELEMENTS)
            PrintLogMessage("AuthManager", "CurrentAuthStatus", "user signed in: " + JSON.stringify(currentUser), LOG_LEVEL_DEBUG)
            if (signInCallback !== undefined)
            {
                signInCallback()
            }
        }
        else
        {
            SetSignedInUserProfile("", "", "")
            ShowOrHideSignedInUserProfile(HIDE_ELEMENTS)
            PrintLogMessage("AuthManager", "CurrentAuthStatus", "user not signed in", LOG_LEVEL_INFO)
            if(notSignedInCallback !== undefined) 
            {
                notSignedInCallback()
            }
        }
    })
}

AuthManager.prototype.SignOut = function()
{
    PrintLogMessage("AuthManager", "SignOut", "start process sign out", LOG_LEVEL_INFO)
    this.firebase.auth().signOut().then(function () {
        // Sign-out successful.
        PrintLogMessage("AuthManager", "SignOut", "sign out successfully. bye bye", LOG_LEVEL_INFO)
    }).catch(function (error) {
        // An error happened.
        PrintLogMessage("AuthManager", "SignOut", "sign out failed: " + error, LOG_LEVEL_ERROR)
    });
}

AuthManager.prototype.IsUserSignedIn = function()
{
    currentUserInfo = JSON.stringify(this.firebase.auth().currentUser)
    PrintLogMessage("AuthManager", "IsUserSignedIn", "check this user already signed in: " + currentUserInfo, LOG_LEVEL_DEBUG)
    if (this.firebase.auth().currentUser)
    {
        PrintLogMessage("AuthManager", "IsUserSignedIn", "yes this user already signed in", LOG_LEVEL_INFO)
        return true;
    }
    else
    {
        PrintLogMessage("AuthManager", "IsUserSignedIn", "no, this user not signed in", LOG_LEVEL_WARN)
        return false;
    }
}

AuthManager.prototype.GenerateVerifyToken = function(callbackFunc)
{
    this.firebase.auth().currentUser.getIdToken(/* forceRefresh */ true)
        .then(function (idToken) {
            // Send token to your backend via HTTPS
            // ...
            PrintLogMessage("AuthManager", "GenerateVerifyToken", "generate token successfully", LOG_LEVEL_INFO)
            callbackFunc(idToken)
        })
        .catch(function (error) {
            // Handle error
            PrintLogMessage("AuthManager", "GenerateVerifyToken", "cannot generate token", LOG_LEVEL_WARN)
            callbackFunc(null)
        });
}