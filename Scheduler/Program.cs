﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scheduler.Resources;

namespace Scheduler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /* 
                  ################### START OF SCRIPT #################################
 
        -- Replace <schema name> with your schema name on the USE line Below:
 
        USE <schema name>;
 
        --
        -- populate table `country`
        --
        INSERT INTO `country` VALUES 
        (1,'US','2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),
        (2,'Canada','2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),
        (3,'Norway','2019-01-01 00:00:00','test','2019-01-01 00:00:00','test');
        --
        -- populate table `city`
        --
        INSERT INTO `city` VALUES 
        (1,'New York',1,'2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),
        (2,'Los Angeles',1,'2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),
        (3,'Toronto',2,'2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),
        (4,'Vancouver',2,'2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),
        (5,'Oslo',3,'2019-01-01 00:00:00','test','2019-01-01 00:00:00','test');
        --
        -- populate table `address`
        --
        INSERT INTO `address` VALUES 
        (1,'123 Main','',1,'11111','555-1212','2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),
        (2,'123 Elm','',3,'11112','555-1213','2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),
        (3,'123 Oak','',5,'11113','555-1214','2019-01-01 00:00:00','test','2019-01-01 00:00:00','test');
        --
        -- populate table `customer`
        --
        INSERT INTO `customer` VALUES 
        (1,'John Doe',1,1,'2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),
        (2,'Alfred E Newman',2,1,'2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),
        (3,'Ina Prufung',3,1,'2019-01-01 00:00:00','test','2019-01-01 00:00:00','test');
        --
        -- populate table `user`
        --
        INSERT INTO `user` VALUES 
        (1,'test','test',1,'2019-01-01 00:00:00','test','2019-01-01 00:00:00','test');
        --
        -- populate table `appointment`
        --
        INSERT INTO `appointment` VALUES 
        (1,1,1,'not needed','not needed','not needed','not needed','Presentation','not needed','2019-01-01 00:00:00','2019-01-01 00:00:00','2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),
        (2,2,1,'not needed','not needed','not needed','not needed','Scrum','not needed','2019-01-01 00:00:00','2019-01-01 00:00:00','2019-01-01 00:00:00','test','2019-01-01 00:00:00','test');
 
 
        ######################### END OF SCRIPT #############################
 
         */
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DBConnection.startConnection();
            Application.Run(new FormMainMenu());
            DBConnection.closeConnection();
        }
    }
}
