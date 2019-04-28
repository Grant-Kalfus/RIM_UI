function RIM_robot = createRIM(tc1, tc2, tc3, tc4, tc5, tc6)

r = struct('theta', [tc1, tc2, tc3, tc4, tc5, tc6],... % Pulled from encoders
    'alpha', [pi/2 0 pi/2 -pi/2 pi/2 0],...            % Never changes
    'r', [53.975 304.8 0 0 0 0],...                % Never changes
    'd', [271.78 0 0 276.225 0 0],...   % Never changes
    'base', [0; 0; 0]);                        % Never changes

RIM_robot = r;
return;
end

%'T', repmat(zeros(4), 1, 1, N_DOFS),... % See note in fkRIM