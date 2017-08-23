/*global require*/
(function (require) {
    'use strict';

    var applicationDirectory = 'modules';

    var version = document.getElementById('ver').value;
    var ver = '';
    if (version && version.length > 0) {
        ver = version;
    }

    var environment = document.getElementById('env').value;
    var env = '';
    if (environment && environment.length > 0) {
        env = environment + '.';
    }


    var minFlag = document.getElementById('min').value;
    var min = ''; // Set Min for Production
    if (minFlag === 1) {
        min = '.min';
    }

    var baseUrls = {
        app: applicationDirectory,
        plugins: 'vendors',
        common: 'common',
        commonService: 'common/services',
        commonConfig: 'common/configs',
        commonDirective: 'common/directives',
        commonModel: 'common/models',
        commonContant: 'common/constants',
        commonFilter: 'common/filters'
    };

    var paths = {
        setPlugin: function (file) {
            if (file.indexOf('.min') > -1) {
                return baseUrls.plugins + '/' + file;
            } else {
                return baseUrls.plugins + '/' + file + min;
            }
        },
        setCommonModule: function (file) {
            return baseUrls.common + '/' + file + min;
        },
        setCommonService: function (file) {
            return baseUrls.commonService + '/' + file + min;
        },
        setCommonFilter: function (file) {
            return baseUrls.commonFilter + '/' + file + '.filter' + min;
        },
        setCommonConfig: function (file) {
            return baseUrls.commonConfig + '/' + env + file + min;
        },
        setCommonDirective: function (module, file) {
            return baseUrls.commonDirective + '/' + module + '/' + file + '.directive' + min;
        },
        setCommonModel: function (module, file) {
            return baseUrls.commonModel + '/' + module + '/' + file + '.model' + min;
        },
        setCommonConstant: function (file) {
            return baseUrls.commonContant + '/' + file + min;
        },
        setService: function (module, file) {
            return baseUrls.app + '/' + module + '/services/' + file + '.service' + min;
        },
        setModel: function (module, file) {
            return baseUrls.app + '/' + module + '/models/' + file + '.model' + min;
        },
        setRoot: function (file) {
            return file + min;
        }
    };

    var baseUrlPath = "/Scripts/";

    var sPath = document.getElementById('sPath').value;
    if (sPath && sPath.length > 0) {
        baseUrlPath = sPath;
    }

    require.config({
        urlArgs: (environment === 'local') ? "ts=" + new Date().getTime() : "ver=" + ver,
        waitSeconds: 15,
        baseUrl: baseUrlPath,
        optimizeAllPluginResources: true,
        paths: {
            'app': paths.setRoot('app'),
            'app.routes': paths.setRoot('app.routes'),
            'app.common': paths.setRoot('app.common'),

            // Plugins
            'angularAMD': paths.setPlugin('angularAMD'),
            'angularFileUpload': paths.setPlugin('angular-file-upload'),
            'angularFileUploadShim': paths.setPlugin('angular-file-upload-shim'),
            'angularInputMatch': paths.setPlugin('angular-input-match'),
            'angularRecaptcha': paths.setPlugin('angular-recaptcha'),
            'angularSwitch': paths.setPlugin('angular-bootstrap-switch'),
            'angularTree': paths.setPlugin('angular-ui-tree'),
            'ngload': paths.setPlugin('ngload'),
            'tagsInput': paths.setPlugin('tags-input.min'),
            'ngImgCrop': paths.setPlugin('angular-img-crop'),

            // Common modules
            'app.directive': paths.setCommonModule('app.directive'),

            // Common Configs
            'generalConfig': paths.setCommonConfig('general.config'),

            // Common Services
            'pathService': paths.setCommonService('path.service'),
           
            // Common Filters
            //'capitalizeSentenceFilter': paths.setCommonFilter('capitalizeSentence')
        },
        shim: {
            'pathService': ['generalConfig'],
            'angularFileUpload': ['angularFileUploadShim'],
            'common': ['pathService']
        },
        deps: ['app']
    });
})(require);


