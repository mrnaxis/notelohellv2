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

function ShowErrorDate() {
    var resp = dateValid($("#birth_reg")[0])
    if (!resp)
        ManageError("birthGroup", "Data Inválida", false);
    else
        ManageError("birthGroup", "  ", true);
    return resp;
}

function ShowErrorPW() {
    var resp1 = checkCampos($("#pass_reg"), $("#passConf_reg"), 0)
    var resp2 = checkCampos($("#pass_reg"), $("#passConf_reg"), 3);
    if (!resp1 || !resp2)
        ManageError("pwGroup", !resp2?"Senhas não conferem":"Digite uma senha", false);
    else
        ManageError("pwGroup", "  ", true);
    return resp1 || resp2;
}

$(document).ready(function () {
    $("#btn_registrar").on("click", function () {
        return ShowErrorDate() && ShowErrorPW();
    });

    $("#passConf_reg").on("input", function () {
        if (!checkCampos($("#pass_reg"), $("#passConf_reg"), 0))
            ManageError("pwGroup", "Senhas não conferem", false);
        else
            ManageError("pwGroup", "  ", true);
    });

    $("#birth_reg").on("keydown", function (date) {
        if (date.key.search(/Backspace|Del|Tab/g) === -1) {
            if ((date.target.value.length === 2 || date.target.value.length === 5) && date.key.search('/') === -1)
                date.target.value += '/';

            if (date.key.search(/\D/g) >= 0 && date.key.search("/") === -1)
                return false;
        }
    });

    $("#birth_reg").on("blur", function (date) {
        if (!dateValid(date.target))
            ManageError("birthGroup", "Data Inválida", false);
        else
            ManageError("birthGroup", "  ", true);
    });
});