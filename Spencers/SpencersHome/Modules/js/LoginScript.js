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