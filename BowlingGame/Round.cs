﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame
{
    public class Round
    {
        int[] rolls = new int[21];
        public int currentRoll;

        public Round(bool active)
        {
            Active = active;
        }

        public bool Active { get; set; }

        public void Roll(int pins)
        {
            rolls[currentRoll] = pins;
            currentRoll++;
        }

        public int Score()
        {
            int roll = 0;
            int score = 0;
        
            for(int frame = 0; frame < 10; frame++)
            {

                if (isStrike(roll))
                {
                    score += 10 + rolls[roll + 1] + rolls[roll + 2];
                    roll++;
                }
                if (isSpare(roll))
                {
                    score += 10 + rolls[roll + 2];
                    roll += 2;
                }
                else
                {
                    score += rolls[roll] + rolls[roll + 1];
                    roll += 2;
                }
            }

            return score;

        }

        private bool isStrike(int roll)
        {
            return rolls[roll] == 10;
        }

        private bool isSpare(int roll)
        {
            return rolls[roll] + rolls[roll + 1] == 10;
        }
    }
}
