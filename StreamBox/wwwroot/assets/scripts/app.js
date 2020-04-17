var minmaxButton = document.getElementById('minmax-button'),
    maximizeICON = document.getElementById('maximize-icon'),
    minimizeICON = document.getElementById('minimize-icon');


var timeShiftCheckbox    = document.getElementById('timeshift-checkbox'),
    loadBalanceCheckbox  = document.getElementById('loadbalance-checkbox'),
    loadBalanceDiv       = document.getElementById('loadbalance-div'),
    loadbalanceIcon      = document.getElementById('loadbalance-icon'),
    timeshiftChecked     = document.getElementById('timeshift-icon'),
    timeShiftDiv         = document.getElementById('timeshift-div'),
    timeshiftIcon        = document.getElementById('timeshift-icon');



minmaxButton.onclick = function()
{
    if(document.fullscreen)
    {
        document.exitFullscreen();
    }
    else
    {
        document.documentElement.requestFullscreen();
    }
}

document.addEventListener("fullscreenchange" , function()
{
    if(document.fullscreen)
    {
        minimizeICON.classList.remove("hide");
        minimizeICON.classList.add("show");
        maximizeICON.classList.remove("show");
        maximizeICON.classList.add("hide");
    }
    else
    {
        maximizeICON.classList.remove("hide");
        maximizeICON.classList.add("show");
        minimizeICON.classList.remove("show");
        minimizeICON.classList.add("hide");
    }
})
    
    loadBalanceDiv.onclick = function()
    {
        loadBalanceCheckbox.click();
    };

    timeShiftDiv.onclick = function()
    {
        timeShiftCheckbox.click();
    }


    timeShiftCheckbox.onclick = function()
    {
        if(timeShiftCheckbox.checked == true)
        {
            checkedICON.classList.add('checked')
        }
        else
        {
            checkedICON.classList.remove('checked')
        }
    }

    loadBalanceCheckbox.onclick = function()
    {
        console.log("clicked");
        if(loadBalanceCheckbox.checked === true)
        {
            loadbalanceIcon.classList.remove('unchecked');
            loadbalanceIcon.classList.add('checked');

            console.log(loadBalanceCheckbox.checked);
        }
        else if(loadBalanceCheckbox.checked === false)
        {
            loadbalanceIcon.classList.remove('checked');
            loadbalanceIcon.classList.add('unchecked');
            console.log(loadBalanceCheckbox.checked);
        }
    }

    timeShiftCheckbox.onclick = function()
    {
        console.log("clicked");
        if(timeShiftCheckbox.checked === true)
        {
            timeshiftIcon.classList.remove('unchecked');
            timeshiftIcon.classList.add('checked');
            
            console.log(timeShiftCheckbox.checked);
        }
        else if(timeShiftCheckbox.checked === false)
        {
            timeshiftIcon.classList.remove('checked');
            timeshiftIcon.classList.add('unchecked');
            console.log(timeShiftCheckbox.checked);
        }
    }