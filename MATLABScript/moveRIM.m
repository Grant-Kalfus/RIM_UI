% tm = "theta move" (calculated from full program)
% tc = "theta current" (Pulled from encoders)
% tp = "target end effector cartesian coordinate position" (from UI)
% t  = "target" for pitch, roll, and yaw (from UI)
% All angles are degrees and positions are millimeters

function [tm1, tm2, tm3, tm4, tm5, tm6] = moveRIM(tc1, tc2, tc3, tc4, tc5, tc6, tpx, tpy, tpz, tpitch, troll, tyaw)
% Define our robot's structure and pull in current theta values from
% encoders
RIM_robot = createRIM(tc1, tc2, tc3, tc4, tc5, tc6);

% Perform Forward Kinematics to calculate current position and orientation
T = fkRIM(RIM_robot);

% Perform Inverse Kinematics to calculate joint solutions (final positions)
elbow = 1; % Try elbow up first (1). If this fails try down (-1).
[tf1, tf2, tf3, tf4, tf5, tf6,success_check] = ikRIM(RIM_robot,elbow,tpx, tpy, tpz, tpitch, troll, tyaw);
if tf1 == -999
    tm1 = -999;
    tm2 = 0;
    tm3 = 0;
    tm4 = 0;
    tm5 = 0;
    tm6 = 0;
    return;
end

if success_check == 0 % Elbow up failed boundry check
    elbow = -1;
    [tf1, tf2, tf3, tf4, tf5, tf6,success_check] = ikRIM(RIM_robot,elbow,tpx, tpy, tpz, tpitch, troll, tyaw);
    if success_check == 0
        tm1 = -999;
        tm2 = 0;
        tm3 = 0;
        tm4 = 0;
        tm5 = 0;
        tm6 = 0;
        return;
    end
end

% Calculate how far to move each joint

[tm1, tm2, tm3, tm4, tm5, tm6] = changeRIM(tc1, tc2, tc3, tc4, tc5, tc6, tf1, tf2, tf3, tf4, tf5, tf6);

end