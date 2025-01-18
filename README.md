# Chess-Bot

## Project Outline
Creating a chess game and bot to win. This project was made in Unity to take advantage of its game making style, whilst still using the fast language C# to subsequently code up the chess bot. Eventually, in accordance with my machine learning modules for my masters degree, the chess bot will incorperate machine learning techniques to solidify my understanding of machine learning and chess bots overall. Initially, however, I will be taking advantage of traditional techniques such as minmax search and alpha-beta pruning. 

### To-Do List
- Create functioning chess game that tracks pieces.
- Create a bot that plays random moves 
- Impliment minmax searching algorithm
- Impliment alpha-beta pruning
- Investigate other techniques including machine learning algorithms and potentially apply these to my bot or a different bot.

## Event Tracker 
- Created a chess board and pieces that render to the screen.
- Created a FEN string translator that reads the current position and positions / despawns the pieces accordingly.
    - Still need to impliment the other rules seen in the FEN string such as white/black to move, castling ability, and en-passant stuff.
- Implimented piece drag and drop movement, with each piece able to snap to the nearest square when dropped by the mouse.
    - Need to impliment updating of the posList List containing the pieces positions.
