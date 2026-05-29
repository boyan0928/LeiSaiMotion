using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace csdmc1c80
{
    public class dmc1c80
    {
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_board_init", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int d1c80_board_init();
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_board_close", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d1c80_board_close();

        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_board_reset", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_board_reset(ushort card);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_get_card_version", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_get_card_version(ushort card);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_get_card_soft_version", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_get_card_soft_version(ushort card, ref ushort firm_id, ref uint sub_firm_id);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_get_client_ID", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_get_client_ID(ushort card);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_get_lib_version", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_get_lib_version();
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_get_card_ID", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_get_card_ID(ushort card);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_get_total_axes", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_get_total_axes(ushort card);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_test_software", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_test_software(ushort card, ushort testid, ushort para1, ushort para2, ushort para3);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_test_hardware", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_test_hardware(ushort card);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_download_firmware", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_download_firmware(ushort card, string pfilename);

        //脉冲输入输出配置
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_set_pulse_outmode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_set_pulse_outmode(ushort axis,ushort outmode);
       

        //添加配置读
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_get_pulse_outmode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_get_pulse_outmode(ushort axis,ref ushort outmode);
        

        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_get_config_INP_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_get_config_INP_PIN(ushort axis,ref ushort enable,ref ushort inp_logic);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_get_config_ERC_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_get_config_ERC_PIN(ushort axis,ref ushort enable,ref ushort erc_logic,ref ushort erc_width,ref ushort erc_off_time);
       
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_get_config_ALM_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_get_config_ALM_PIN(ushort axis,ref ushort enable,ref ushort alm_logic,ref ushort alm_action);

        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_get_config_EL_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_get_config_EL_PIN(ushort axis,ref ushort el_logic,ref ushort el_mode);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_get_config_HOME_PIN_logic", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_get_config_HOME_PIN_logic(ushort axis,ref ushort org_logic,ref ushort filter);

        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_get_config_home_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_get_config_home_mode(ushort axis,ref ushort home_dir,ref double vel,ref ushort home_mode,ref ushort EZ_count);
       
        //专用信号设置函数
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_config_INP_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_config_INP_PIN(ushort axis,ushort enable,ushort inp_logic);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_config_ERC_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_config_ERC_PIN(ushort axis,ushort enable,ushort erc_logic,ushort erc_width,ushort erc_off_time);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_config_EMG_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_config_EMG_PIN(ushort cardno,ushort option,ushort emg_logic);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_get_config_EMG_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_get_config_EMG_PIN(ushort cardno, ref ushort enbale, ref ushort emg_logic);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_config_ALM_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_config_ALM_PIN(ushort axis,ushort enbale,ushort alm_logic,ushort alm_action);
        //new
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_config_EL_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_config_EL_PIN(ushort axis,ushort el_logic,ushort el_mode);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_config_HOME_PIN_logic", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_config_HOME_PIN_logic(ushort axis,ushort org_logic,ushort filter);

        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_write_ERC_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_write_ERC_PIN(ushort axis,ushort sel);

        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_set_backlash", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_set_backlash(ushort axis,int backlash);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_get_backlash", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_get_backlash(ushort axis,ref int backlash);

        //通用输入/输出控制函数
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_read_inbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int d1c80_read_inbit(ushort cardno,ushort bitno);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_write_outbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_write_outbit(ushort cardno,ushort bitno,ushort on_off);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_read_outbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int d1c80_read_outbit(ushort cardno,ushort bitno);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_read_inport", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int d1c80_read_inport(ushort cardno);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_read_outport", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int d1c80_read_outport(ushort cardno);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_write_outport", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_write_outport(ushort cardno,uint port_value);

        //制动函数
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_decel_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_decel_stop(ushort axis,double dec);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_imd_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_imd_stop(ushort axis);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_emg_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_emg_stop();
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_simultaneous_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_simultaneous_stop(ushort axis);

        //位置设置和读取函数
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_get_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int d1c80_get_position(ushort axis);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_set_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_set_position(ushort axis,int current_position);

        //状态检测函数
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_check_done", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int d1c80_check_done(ushort axis);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_axis_io_status", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_axis_io_status(ushort axis);

        //速度设置
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_read_current_speed", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern double d1c80_read_current_speed(ushort axis);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_read_vector_speed", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern double d1c80_read_vector_speed(ushort card);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_change_speed", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_change_speed(ushort axis,double Curr_Vel);

        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_set_vector_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_set_vector_profile(ushort cardno,double s_para,double Max_Vel,double acc,double dec);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_get_vector_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_get_vector_profile(ushort cardno,ref double s_para,ref double Max_Vel,ref double acc,ref double dec);

        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_set_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_set_profile(ushort axis,double option,double Max_Vel,double acc,double dec);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_set_s_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_set_s_profile(ushort axis,double s_para);

        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_get_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_get_profile(ushort axis,ref double option,ref double Max_Vel,ref double acc,ref double dec);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_get_s_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_get_s_profile(ushort axis,ref double s_para);

        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_set_profile_Extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_set_profile_Extern(UInt16 axis, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double Stop_Vel);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_get_profile_Extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_get_profile_Extern(UInt16 axis, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double Stop_Vel);

        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_reset_target_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_reset_target_position(ushort axis,int dist);

        //单轴定长运动
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_pmove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_pmove(ushort axis, int Dist, ushort posi_mode);
        
        //单轴连续运动
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_vmove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_vmove(ushort axis, ushort dir, double vel);

       

        //找原点
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_config_home_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_config_home_mode(ushort axis, ushort home_dir, double vel, ushort home_mode, ushort EZ_count);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_home_move", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_home_move(ushort axis);

     


        

        //软件限位功能
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_config_softlimit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_config_softlimit(ushort axis, ushort ON_OFF, ushort source_sel, ushort SL_action, int N_limit,int P_limit);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_get_config_softlimit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_get_config_softlimit(ushort axis, ref ushort ON_OFF, ref ushort source_sel, ref ushort SL_action, ref int N_limit, ref int P_limit);

        //硬件限位使能

        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_Enable_EL_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_Enable_EL_PIN(UInt16 axis, UInt16 enable);
        [DllImport("dmc1c80.dll", EntryPoint = "d1c80_get_Enable_EL_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern uint d1c80_get_Enable_EL_PIN(UInt16 axis, UInt16 enable);

        //PC库错误码
        enum ERR_CODE_DMC
        {
        ERR_NOERR = 0,          //成功      
        ERR_UNKNOWN = 1,
        ERR_PARAERR = 2,    
    
        ERR_TIMEOUT = 3,
        ERR_CONTROLLERBUSY = 4,
        ERR_CONNECT_TOOMANY = 5,    

        ERR_CONTILINE = 40,
        ERR_CANNOT_CONNECTETH = 8,
        ERR_HANDLEERR = 9, 
        ERR_SENDERR = 10, 
        ERR_FIRMWAREERR = 12, //固件文件错误
        ERR_FIRMWAR_MISMATCH = 14, //固件不匹配
    
        ERR_FIRMWARE_INVALID_PARA    = 20,  //固件参数错误
        ERR_FIRMWARE_PARA_ERR    = 20,  //固件参数错误2
        ERR_FIRMWARE_STATE_ERR    = 22, //固件当前状态不允许操作
        ERR_FIRMWARE_LIB_STATE_ERR    = 22, //固件当前状态不允许操作2
        ERR_FIRMWARE_CARD_NOT_SUPPORT    = 24,  //固件不支持的功能 控制器不支持的功能
        ERR_FIRMWARE_LIB_NOTSUPPORT    = 24,    //固件不支持的功能2
        };
            
    }
}
