function TabMenuManager()
{
    PrintLogMessage("TabMenuManager", "TabMenuManager", "init", LOG_LEVEL_INFO)
}

TabMenuManager.prototype.ChangeSecondMenu = function (menuLabel, menuUrl)
{
    PrintLogMessage("TabMenuManager", "ChangeSecondMenu", "change menu button to: " + menuLabel + ", " + menuUrl, LOG_LEVEL_DEBUG)
    $($($("#listOfMenu").children("li")[1]).find("a")).text(menuLabel);
    $($($("#listOfMenu").children("li")[1]).find("a")).attr("href", menuUrl);
}

TabMenuManager.prototype.ActiveSecondMenu = function() 
{
    PrintLogMessage("TabMenuManager", "ActiveSecondMenu", "set second menu button active", LOG_LEVEL_INFO)
    $($("#listOfMenu").children("li")[1]).attr("class", "active")
    $($("#listOfMenu").children("li")[0]).removeAttr("class")
}

TabMenuManager.prototype.DisactiveSecondMenu = function() 
{
    PrintLogMessage("TabMenuManager", "DisactiveSecondMenu", "set second menu button disactive", LOG_LEVEL_INFO)
    $($("#listOfMenu").children("li")[0]).attr("class", "active")
    $($("#listOfMenu").children("li")[1]).removeAttr("class")
}