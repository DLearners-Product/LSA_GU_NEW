using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class EnablerCmtsDB
{
    public string welcome;
    public string d_review;
    public string r_review_poem;
    public string intro_to_letter_g;
    public string reading_g;
    public string trace_the_letter_g;
    public string look_at_pic_and_say;
    public string color_letter_d;
    public string connect_g;
    public string listening_the_game;
    public string g_story;
    public string intro_to_u;
    public string reading_u;
    public string trace_the_letter_u;
    public string click_on_the_pic;
    public string matching_u;
    public string u_story;
    public string goodbye;

    public EnablerCmtsDB()
    {
        welcome = Main_Blended.OBJ_main_blended.enablerComments[0];
        d_review = Main_Blended.OBJ_main_blended.enablerComments[1];
        r_review_poem = Main_Blended.OBJ_main_blended.enablerComments[2];
        intro_to_letter_g = Main_Blended.OBJ_main_blended.enablerComments[3];
        reading_g = Main_Blended.OBJ_main_blended.enablerComments[4];
        trace_the_letter_g = Main_Blended.OBJ_main_blended.enablerComments[5];
        look_at_pic_and_say = Main_Blended.OBJ_main_blended.enablerComments[6];
        color_letter_d = Main_Blended.OBJ_main_blended.enablerComments[7];
        connect_g = Main_Blended.OBJ_main_blended.enablerComments[8];
        listening_the_game = Main_Blended.OBJ_main_blended.enablerComments[9];
        g_story = Main_Blended.OBJ_main_blended.enablerComments[10];
        intro_to_u = Main_Blended.OBJ_main_blended.enablerComments[11];
        reading_u = Main_Blended.OBJ_main_blended.enablerComments[12];
        trace_the_letter_u = Main_Blended.OBJ_main_blended.enablerComments[13];
        click_on_the_pic = Main_Blended.OBJ_main_blended.enablerComments[14];
        matching_u = Main_Blended.OBJ_main_blended.enablerComments[15];
        u_story = Main_Blended.OBJ_main_blended.enablerComments[16];
        goodbye = Main_Blended.OBJ_main_blended.enablerComments[17];
    }
}