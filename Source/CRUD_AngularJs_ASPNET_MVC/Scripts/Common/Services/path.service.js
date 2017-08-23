define(['angularAMD', 'generalConfig'], function (angularAMD, generalConfig) {
    'use strict';

    var modulesDirectory = 'Scripts/modules';
    var commonDirectory = 'Scripts/common';

    var baseUrlPath = document.getElementById('tPath').value;

    var min = '.min';

    if (!generalConfig.minified) {
        min = '';
    }

    var cacheBuster = '';
    if (generalConfig.isDebugMode) {
        cacheBuster = '?ts=' + new Date().getTime() + Math.random();
    } else {
        var version = document.getElementById('ver').value;
        if (version && version.length > 0) {
            cacheBuster = "?ver=" + version;
        }
    }

    return {
        setController: function (module, controller) {
            return '/' + modulesDirectory + '/' + module + '/controllers/' + controller + '.controller' + min + '.js';
        },
        setCommonController: function (module, controller) {
            return '/' + commonDirectory + '/' + module + '/' + controller + '.controller' + min + '.js';
        },
        setView: function (module, view) {
            return baseUrlPath + modulesDirectory + '/' + module + '/views/' + view + min + '.html' + cacheBuster;
        },
        setCommonDirectiveView: function (module, view) {
            return baseUrlPath + commonDirectory + '/directives/' + module + '/' + view + min + '.html' + cacheBuster;
        },
        setCommonView: function (module, view) {
            return baseUrlPath + commonDirectory + '/views/' + module + '/' + view + min + '.html' + cacheBuster;
        },
        setCommonModalView: function (module, view) {
            return baseUrlPath + commonDirectory + '/modals/' + module + '/' + view + min + '.html' + cacheBuster;
        }
    };
});

