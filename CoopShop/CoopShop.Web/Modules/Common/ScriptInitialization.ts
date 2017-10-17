/// <reference path="../Common/Helpers/LanguageList.ts" />

namespace CoopShop.ScriptInitialization {
    Q.Config.responsiveDialogs = true;
    Q.Config.rootNamespaces.push('CoopShop');
    Serenity.EntityDialog.defaultLanguageList = LanguageList.getValue;
}