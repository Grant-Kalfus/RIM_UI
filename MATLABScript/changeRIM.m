function [tm1, tm2, tm3, tm4, tm5, tm6] = changeRIM(tc1, tc2, tc3, tc4, tc5, tc6, tf1, tf2, tf3, tf4, tf5, tf6)
tm1 = tf1 - tc1;
tm2 = tf2 - tc2;
tm3 = tf3 - tc3;
tm4 = tf4 - tc4;
tm5 = tf5 - tc5;
tm6 = tf6 - tc6;
end