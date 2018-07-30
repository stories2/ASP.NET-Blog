function UserManager(firebase) {
    PrintLogMessage("UserManager", "UserManager", "init", LOG_LEVEL_INFO)
    this.firebase = firebase
    this.dataTransferManager = new DataTransferManager()
}

UserManager.prototype.AppendUserInfo = function (userDisplayName, userEmail, userUid, token, callbackFunc) {
    PrintLogMessage("UserManager", "AppendUserInfo", "append new user to server", "display name: " + 
        userDisplayName + " email: " + userEmail + " uid: " + userUid, LOG_LEVEL_DEBUG)

    userData = {
        "displayName": userDisplayName,
        "email": userEmail,
        "uid": userUid
    }
    PrintLogMessage("UserManager", "AppendUserInfo", "api endpoint: " + ENDPOINT_APPEND_NEW_USER + " data: " + JSON.stringify(userData), LOG_LEVEL_DEBUG)
    this.dataTransferManager.PostRequestWithCallbackFunc(
        ENDPOINT_APPEND_NEW_USER,
        userData,
        function (resultMsg) {
            PrintLogMessage("UserManager", "AppendUserInfo", "successfully user data appended", LOG_LEVEL_INFO)
            if (callbackFunc !== undefined) {
                callbackFunc(resultMsg)
            }
        },
        function (errorMsg) {
            PrintLogMessage("UserManager", "AppendUserInfo", "failed to append user data: " + errorMsg, LOG_LEVEL_ERROR)
            callbackFunc(errorMsg)
        }, token)
}

UserManager.prototype.GetCurrentUserBasicInfo = function (callbackFunc) {
    PrintLogMessage("UserManager", "GetCurrentUserBasicInfo", "check is user already signed in", LOG_LEVEL_INFO)
    firebaseAuth = this.firebase.auth()
    currentUser = firebaseAuth.currentUser
    if (currentUser) {
        PrintLogMessage("UserManager", "GetCurrentUserBasicInfo", "ok, user signed in", LOG_LEVEL_INFO)
        userDisplayName = currentUser["displayName"]
        userEmail = currentUser["email"]
        userUid = currentUser["uid"]
        PrintLogMessage("UserManager", "GetCurrentUserBasicInfo", "name: " + userDisplayName + " email: " + userEmail + " uid: " + userUid, LOG_LEVEL_DEBUG)

        if (callbackFunc !== undefined) {
            callbackFunc(userDisplayName, userEmail, userUid)
        }
    }
    else {
        PrintLogMessage("UserManager", "GetCurrentUserBasicInfo", "no, user not signed in", LOG_LEVEL_WARN)
    }
}