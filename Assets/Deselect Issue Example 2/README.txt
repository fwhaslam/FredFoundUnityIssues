Problem With Deselect
=========================

My goal was to popup a panel, pick something inside, then have it close.

If there is a click anywhere outside the panel, it should close.

Deseleft seems to be the only tool which can cloase on object based on an 
'outside' click,  short of wiring up every click to a 'closePopup' event.

But it looks like deselect events occur within the panel, AND are delivered 
before pointerClick events.  So my panel is not acvtive when the pointer click 
is supposed to happen for the buttons.
