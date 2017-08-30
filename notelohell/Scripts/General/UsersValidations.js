// User Affais --> minify it!
//Using Verifications.js --> mind it uses, no intellisense active
function ValidateVariable(variableObject) {
    if (typeof variableObject !== "undefined" && variableObject !== null) {
        if (typeof variableObject === "object") {
            for (var i = 0; i < variableObject.length; i++) {
                if (typeof variableObject[i] === "undefined" || variableObject === null)
                    return false;
            }
        }
        //if any case is different than null or undefined return true motherfucker!
        return true;
    }
}

function ManageError(idgroup, idgroupmessage, hide) {
    if (ValidateVariable([idgroup, idgroupmessage, hide])
        && typeof idgroup === "string" && typeof idgroupmessage === "string"
        && typeof hide === "boolean") {
        var group = idgroup;
        if (group.toLowerCase().indexOf("grou") === -1)
            group += "Group";
        if (!hide) {
            $("#" + group).addClass("has-error");
            $("#" + group + "Error").removeClass("hide");
        }
        else {
            $("#" + group).removeClass("has-error");
            $("#" + group + "Error").addClass("hide");
        }
        $("#" + group + "Error").text(idgroupmessage);
    }
}

//Checking Sector, please show up your ID.

function ShowErrorDate(JQueryObj) {
    var resp = dateValid(JQueryObj[0])
    if (!resp)
        ManageError("birthGroup", "Data Inválida", false);
    else
        ManageError("birthGroup", "  ", true);
    return resp;
}

function ShowErrorNames(JField, msg, idgroup) {
    var resp = checkCampos(JField, "", 2);
    if (!resp)
        ManageError(idgroup, msg, false);
    else
        ManageError(idgroup, "  ", true);
    return resp;
}

function ShowErrorPW() {
    var resp1 = checkCampos($("#pass_reg"), $("#passConf_reg"), 0)
    var resp2 = checkCampos($("#pass_reg"), $("#passConf_reg"), 3);
    if (!resp1 || !resp2)
        ManageError("pwGroup", !resp2?"Senhas não conferem":"Digite uma senha", false);
    else
        ManageError("pwGroup", "  ", true);
    return resp1 && resp2;
}

function ShowErrors() {
    var errors = [ShowErrorDate($("#birth_reg")), ShowErrorNames($("#email_reg"), "Email Obrigatório", "mailGroup"),
        ShowErrorNames($("#gametag_reg"), "GameTag Obrigatória", "tagGroup"),
        ShowErrorNames($("#nome_reg"), "Nome Obrigatório", "nameGroup"),
        ShowErrorPW()];

    for (var i = 0; i < errors.length; i++) {
        if (!errors[i] && typeof errors[i] !== 'undefined')
            return false;
    }
    return true;
}