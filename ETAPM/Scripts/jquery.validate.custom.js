
$.validator.unobtrusive.adapters.add('filetype', ['validtypes','maxfilesize'], function (options) {
    options.rules['filetype'] = {
        validtypes: options.params.validtypes.split(','),
        maxfilesize: Number(options.params.maxfilesize)
    };
    options.messages['filetype'] = options.message;
     
});

$.validator.addMethod("filetype", function (value, element, param) {

    for (var i = 0; i < element.files.length; i++) {
        var file = element.files[i];
        var extension = getFileExtension(file.name);
        if ($.inArray(extension, param.validtypes) === -1) {
            return false;
        }
          
        if (file.size > param.maxfilesize)
            return false;
    }

    return true;
});

function getFileExtension(fileName) {
    if (/[.]/.exec(fileName)) {
        return /[^.]+$/.exec(fileName)[0].toLowerCase();
    }
    return null;
}
 
function IsInteger(no) {
    return /^\+?\d+$/.test(no);
}
