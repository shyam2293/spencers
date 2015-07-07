function checkTextBox(textBoxId, spanId) {
    with (document.getElementById(textBoxId)) {
        if (value.length == 0) {
            document.getElementById(spanId).innerHTML = "<font color='red'>required field</font>";
            return false;
        }
        else {
            document.getElementById(spanId).innerHTML = "";
            return true;
        }
    }
}

function checkConfirmPassword(passwordId, confirmId, spanId) {
    var password = document.getElementById(passwordId);
    with (document.getElementById(confirmId)) {
        if (value.length == 0) {
            document.getElementById(spanId).innerHTML = "<font color='red'>  Confirm Password required</font>";
            return false;
        }
        else if (password.value == value) {
            document.getElementById(spanId).innerHTML = "";
            return true;
        }
        else {
            document.getElementById(spanId).innerHTML = "<font color='red'>  Confirm Password does not match</font>";
            return false;
        }
    }
}

function checkSecurityQuestion(listId, spanId) {
    with (document.getElementById(listId)) {
        if (selectedIndex == 0) {
            document.getElementById(spanId).innerHTML = "<font color='red'>  Select Security Question</font>";
            return false;
        }
        else {
            document.getElementById(spanId).innerHTML = "";
            return true;
        }
    }
}


function checkTelephone(textBoxId, spanId) {
    var re = /^[0-9]{10}$/;
    with (document.getElementById(textBoxId)) {
        if (!re.test(value) || value.length == 0) {
            document.getElementById(spanId).innerHTML = "<font color='red'>  Telephone number must be 10 digits";
            return false;
        }
        else {
            document.getElementById(spanId).innerHTML = "";
            return true;
        }
    }
}

function checkEmail(textBoxId, spanId) {
    var re = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    with (document.getElementById(textBoxId)) {
        if (!re.test(value) || value.length == 0) {
            document.getElementById(spanId).innerHTML = "<font color='red'>  Email is not in correct format</font>";
            return false;
        }
        else {
            document.getElementById(spanId).innerHTML = "";
            return true;
        }
    }
}

function checkLicenceAgreement(checkBoxId, spanId) {
    with (document.getElementById(checkBoxId)) {
        if (checked == false) {
            document.getElementById(spanId).innerHTML = "<font color='red'>  Licence agreement not selected</font>";
            return false;
        }
        else {
            document.getElementById(spanId).innerHTML = "";
            return true;
        }
    }

}
