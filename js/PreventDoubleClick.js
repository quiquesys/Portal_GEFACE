function ResetToDefault(btn, oldValue, btn2,btn3) {
            btn.disabled = false;
            btn.value = oldValue;
            if (btn2 != null) {
                btn2.disabled = false;
            }
            if (btn3 != null) {
                btn3.disabled = false;
            }
            $(function() { closeDialog('loading'); });
        }
        //browser properties
        var Browser = {
            Version: function() {
                var version = 999;
                if (navigator.appVersion.indexOf("MSIE") != -1) {
                    version = parseFloat(navigator.appVersion.split("MSIE")[1]); return version;
                }
            },
            Name: navigator.appName,
            isIE: function() {
                if (navigator.appVersion.indexOf("MSIE") != -1) {
                    return true;
                }
                return false;
            }
        };

        //Handle Page_Validators is not defined error
        //http://www.velocityreviews.com/forums/t88987-pagevalidators-error.html
        function HasPageValidators() {
            var hasValidators = false;
            try {
                if (Page_Validators.length > 0) {
                    hasValidators = true;
                }
            }
            catch (error) { }

            return hasValidators;
        }


        function SetImage(btn) {

            if (btn.type == "image") {
                btn.src = null;
                btn.style.width = '100px';
                btn.style.height = '20px';
                btn.style.backgroundImage = 'url(../img/ajax-spinner.gif)';
                btn.style.backgroundRepeat = 'no-repeat';
                btn.style.backgroundPosition = 'center';
            }
            else {
                //somehow backgroundImage not working with IE 7
                if (Browser.isIE() && Browser.Version() == 7) {
                    btn.style.background = 'url(../img/ajax-spinner.gif)';
                    btn.style.backgroundRepeat = 'no-repeat';
                    btn.style.backgroundPosition = 'center';
                }
                else {
                    btn.style.backgroundImage = 'url(../img/ajax-spinner.gif)';
                    btn.style.backgroundRepeat = 'no-repeat';
                    btn.style.backgroundPosition = 'center';
                }
            }
        }

        //enable the button and restore the original text value for browsers other than IE
        function EnableOnUnload(btn, btnText, btn2,btn3) {
            if (!Browser.isIE()) {
                window.onunload = function() {
                    ResetToDefault(btn, btnText, btn2,btn3);
                };
            }
        }

        //check if the validator have any control to validate
        function EnableValidator(validator) {
            var controlToValidate = document.getElementById(validator.controltovalidate);

            if (controlToValidate !== null) {
                // alert(controlToValidate.id);
                ValidatorEnable(validator);
                return true;
            }
            ValidatorEnable(validator, false);

            return false;
        }

        function disableBtn(btnID,btnID2,btnID3, newText, grupoValidador) {//se agrego un tercer parametro, donde se indica a que validationGroup pertence el boton, esto para efectos de indicar que grupo debe validar
            var btn = document.getElementById(btnID);
            var btn2 = document.getElementById(btnID2);
            var btn3 = document.getElementById(btnID3);
            var oldValue = btn.value;            
            btn.disabled = true;
            btn.value = newText;
            if (btn2 != null) {             
                btn2.disabled = true;
            }
            if (btn3 != null) {
                btn3.disabled = true;
            }


            //if validator control present
            if (HasPageValidators()) {

                Page_IsValid = null;

                //http://sandblogaspnet.blogspot.com/2009/04/calling-validator-controls-from.html
                //double check, if validator not null
                if (Page_Validators !== 'undefined' && Page_Validators !== null) {
                    //Looping through the whole validation collection.
                    for (var i = 0; i < Page_Validators.length; i++) {

                        var validator = Page_Validators[i];

                        //check if control to validate is enable
                        if (EnableValidator(validator)) {

                            if (Page_Validators[i].validationGroup == grupoValidador) {//Este if se agrego, para que valide solo el validationGroup que se envia como parametro.

                                if (!Page_Validators[i].isvalid) { //if not valid
                                    ResetToDefault(btn, oldValue, btn2,btn3); //break;
                                }
                            }
                        }
                    }

                    //   else { //if valid
                    var isValidationOk = Page_ClientValidate(grupoValidador); //Page_IsValid; esta funcion se usaba antes, para validar todos los ValidationGroups, se cambio para validar solo uno en especifico

                    //alert('isValidationOk ' + isValidationOk);

                    EnableOnUnload(btn, btn.value, btn2,btn3);
                    if (isValidationOk !== null) {
                        if (isValidationOk) {
                            SetImage(btn);
                            __doPostBack(btnID, '');
                            // break;
                        }
                        else { //page not valid
                            btn.disabled = false;
                            if (btn2 != null) {
                                btn2.disabled = false;
                            }
                            if (btn3 != null) {
                                btn3.disabled = false;
                            }
                        }
                    }
                    //  }

                }
            }
            else { //regular, no validation control present
                // setTimeout("SetImage('" + btn + "')", 5);
                SetImage(btn);
                btn.disabled = true;
                btn.value = newText;
                if (btn2 != null) {
                    btn2.disabled = true;
                }
                if (btn3 != null) {
                    btn3.disabled = true;
                }                
                EnableOnUnload(btn, btn.value, btn2,btn3);
            }
        }

        
		function disableBtn2(btnID, newText) {
            var btn = document.getElementById(btnID);
            var oldValue = btn.value;
            btn.disabled = true;
            btn.value = newText;
            $(function() { openDialog('loading'); });
            //if validator control present
            if (HasPageValidators()) {

                Page_IsValid = null;

                //http://sandblogaspnet.blogspot.com/2009/04/calling-validator-controls-from.html
                //double check, if validator not null
                if (Page_Validators !== 'undefined' && Page_Validators !== null) {
                    //Looping through the whole validation collection.
                    for (var i = 0; i < Page_Validators.length; i++) {

                        var validator = Page_Validators[i];

                        //check if control to validate is enable 
                        if (EnableValidator(validator)) {

                            if (!Page_Validators[i].isvalid) { //if not valid
                                ResetToDefault(btn, oldValue,null,null); //break;
                            }
                        }
                    }

                    //   else { //if valid
                    var isValidationOk = Page_IsValid;

                    //alert('isValidationOk ' + isValidationOk);

                    EnableOnUnload(btn, btn.value,null,null);
                    if (isValidationOk !== null) {
                        if (isValidationOk) {
                            SetImage(btn);
                            __doPostBack(btnID, '');
                            // break;
                        }
                        else { //page not valid
                            btn.disabled = false;
                        }
                    }
                    //  }

                }
            }
            else { //regular, no validation control present
                // setTimeout("SetImage('" + btn + "')", 5);
                SetImage(btn);
                btn.disabled = true; btn.value = newText;
                EnableOnUnload(btn, btn.value,null,null);
            }
        }

		
		//disable those validators where controltovalidate = null
        function DisableValidators() {
            //this will get rid of the Page_Validators is undefined error
            if (typeof (Page_Validators) === 'undefined')
                return;

            if (Page_Validators !== 'undefined' && Page_Validators !== null) {
                for (var i = 0; i < Page_Validators.length; i++) {
                    var validator2 = Page_Validators[i];
                    var controlToValidate2 = document.getElementById(validator2.controltovalidate);
                    if (controlToValidate2 === null) {
                        ValidatorEnable(validator2, false);
                    }
                }
            }
            return false;
        }

        window.onload = DisableValidators;