window.onload = function()
{
   
    var _body = document.getElementsByTagName('body')[0];
    var _timeOfWorking = $('.cofeesection');
    
    _timeOfWorking.on("mouseover", ShowTimeOfWorking);
    _timeOfWorking.on("mouseleave", HideTimeOfWorking);


}
function ShowTimeOfWorking(ev) {
    var target = ev.currentTarget;    
    var f = target.children[1];   
    f.style.visibility = "visible";
};
function HideTimeOfWorking(ev) {
    var target = ev.currentTarget;
    var f = target.children[1];
    f.style.visibility = "";
};