function [tf1, tf2, tf3, tf4, tf5, tf6,success_check] = ikRIM(RIM_robot,elbow,tpx, tpy, tpz, tpitch, troll, tyaw)

%************************************************************************%
% Inverse Kinematic Calculations
%************************************************************************%

wx = sin(deg2rad(troll))*sin(deg2rad(tyaw))+...
    cos(deg2rad(troll))*sin(deg2rad(tpitch))*cos(deg2rad(tyaw));
wy = -1*sin(deg2rad(troll))*cos(deg2rad(tyaw))+...
    cos(deg2rad(troll))*sin(deg2rad(tpitch))*sin(deg2rad(tyaw));
wz = cos(deg2rad(tpitch))*cos(deg2rad(troll));

% Calculate solution to Joint 1
rJ1 = sqrt(tpx*tpx+tpy*tpy);
tf1r = (atan2(tpy,tpx)+asin(RIM_robot.d(2)/rJ1));
tf1 = tf1r*180/pi;

% Calculate solution to Joint 2
V114 = (cos(tf1r)*tpx)+(sin(tf1r)*tpy)-RIM_robot.r(1);
V124 = tpz-RIM_robot.d(1);
rJ2 = sqrt(V114*V114+V124*V124);
k = (RIM_robot.r(2)*RIM_robot.r(2)-(RIM_robot.d(4)*RIM_robot.d(4))-...
    (RIM_robot.r(3)*RIM_robot.r(3))+V114*V114+V124*V124)/(2*RIM_robot.r(2)*rJ2);
if abs(k) > 1
    tf1 = -999;
    tf2 = 0;
    tf3 = 0;
    tf4 = 0;
    tf5 = 0;
    tf6 = 0;
    return;
end

% With elbow up (elbow above line from shoulder to wrist z axes)
tf2r = (atan2(V124,V114)+elbow*acos(k)); 
tf2 = tf2r*180/pi;

% Calculate solution to Joint 3
V214 = tpx*cos(tf1r)*cos(tf2r)+tpy*cos(tf2r)*sin(tf1r)+...
    tpz*sin(tf2r)-RIM_robot.r(2)-cos(tf2r)*RIM_robot.r(1)-...
    RIM_robot.d(1)*sin(tf2r);
V224 = -1*tpx*cos(tf1r)*sin(tf2r)-tpy*sin(tf1r)*sin(tf2r)...
    + tpz*cos(tf2r)+RIM_robot.r(1)*sin(tf2r)-RIM_robot.d(1)*cos(tf2r);
tf3r = atan2(V214,-V224)-atan2(RIM_robot.r(3),RIM_robot.d(4));
tf3 = tf3r*180/pi;

% Calculate solution to Joint 4
V313 = cos(tf2r+tf3r)*(cos(tf1r)*wx+sin(tf1r)*wy)+sin(tf2r+tf3r)*wz;
V323 = sin(tf1r)*wx - cos(tf1)*wy;
tf4r = atan2(V323,V313);
tf4 = tf4r*180/pi;

% Calculate solution to Joint 5
V113 = cos(tf1r)*wx+sin(tf1r)*wy;
tf5r = atan2((cos(tf4r)*V313+sin(tf4r)*V323),...
    (sin(tf2r+tf3r)*V113-cos(tf2r+tf3r)*wz));
tf5 = tf5r*180/pi;

% Calculate solution to Joint 6
V521 = (cos(tf4r)*V313+sin(tf4r)*V323);
V511 = sin(tf2r+tf3r)*V113-cos(tf2r+tf3r)*wz;
tf6r = atan2(V521,V511);
tf6 = tf6r*180/pi;

% Limits for J1
lb1 = -90;
ub1 = 90;

% Limits for J2
lb2 = -12;
ub2 = 135;

% Limits for J3
ub3 = 240;
if tf2 < 0
    lb3 = 75;
elseif tf2 < 5
    lb3 = 40;
elseif tf2 < 10
    lb3 = 25;
elseif tf2 < 15
    lb3 = 10;
elseif tf2 < 20
    lb3 = -5;
else
    lb3 = -60;
end

% Limits for J4
lb4 = -180;
ub4 = 180;

% Limits for J5
lb5 = -135;
ub5 = 135;

% Limits for J6
lb6 = -180;
ub6 = 180;

UL = [ub1, ub2, ub3, ub4, ub5, ub6];
LL = [lb1, lb2, lb3, lb4, lb5, lb6];
TF = [tf1, tf2, tf3, tf4, tf5, tf6];

% Check our thetas against the limits
for i = 1:6
    if (TF(i) <= UL(i)) && (TF(i) >= LL(i))
        success_check = 1;
    elseif (TF(i)+360 <= UL(i)) && (TF(i)+360 >= LL(i))
        TF(i) = TF(i)+360;
        success_check = 1;
    elseif (TF(i)-360 <= UL(i)) && (TF(i)-360 >= LL(i))
        TF(i) = TF(i)-360;
        success_check = 1;
    else
        success_check = 0;
        break
    end
end
return;

end


