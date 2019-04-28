function T = fkRIM(RIM_robot)

%************************************************************************%
% Forward Kinematic Calculations
%************************************************************************%

% This section calculates end effector position and orientation given
% different values of theta based on each joint's position. 

% This section cannot change the structure of the robot (d,r,alpha,etc.)

% Populate the T transformation matrices
temp = eye(4); % Creates 4x4 identity matrix

% Create T matrix (the homogenous transformation matrix of each link
% starting from the base T(:,:,1) to the end effector T(:,:,6). T is a
% matrix containing 6 other matricies, each describing position and
% orientation of each link. This is just to initialize the variable.
T = repmat(zeros(4), 1, 1, 6);

for i = 1 : 1 : 6
    ct = cos(RIM_robot.theta(i));
    st = sin(RIM_robot.theta(i));
    ca = cos(RIM_robot.alpha(i));
    sa = sin(RIM_robot.alpha(i));
    
    temp = temp * [ct -1*st*ca st*sa RIM_robot.r(i)*ct;...
        st ct*ca -1*ct*sa RIM_robot.r(i)*st;...
        0 sa ca RIM_robot.d(i);...
        0 0 0 1];
    T(:,:,i) = temp;
end
    
% Adjust the position to account for the base location
for i = 1:6
    T(1:3,4,i) = T(1:3,4,i) + RIM_robot.base;
end
return;
end