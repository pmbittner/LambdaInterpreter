// Generated from C:/Users/Paul Bittner/Documents/Projects/LambdaInterpreter/LambdaInterpreter/res/Grammar\LambdaParser.g4 by ANTLR 4.8
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link LambdaParser}.
 */
public interface LambdaParserListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link LambdaParser#lambdaTerm}.
	 * @param ctx the parse tree
	 */
	void enterLambdaTerm(LambdaParser.LambdaTermContext ctx);
	/**
	 * Exit a parse tree produced by {@link LambdaParser#lambdaTerm}.
	 * @param ctx the parse tree
	 */
	void exitLambdaTerm(LambdaParser.LambdaTermContext ctx);
	/**
	 * Enter a parse tree produced by {@link LambdaParser#abstraction}.
	 * @param ctx the parse tree
	 */
	void enterAbstraction(LambdaParser.AbstractionContext ctx);
	/**
	 * Exit a parse tree produced by {@link LambdaParser#abstraction}.
	 * @param ctx the parse tree
	 */
	void exitAbstraction(LambdaParser.AbstractionContext ctx);
	/**
	 * Enter a parse tree produced by {@link LambdaParser#variable}.
	 * @param ctx the parse tree
	 */
	void enterVariable(LambdaParser.VariableContext ctx);
	/**
	 * Exit a parse tree produced by {@link LambdaParser#variable}.
	 * @param ctx the parse tree
	 */
	void exitVariable(LambdaParser.VariableContext ctx);
	/**
	 * Enter a parse tree produced by {@link LambdaParser#brackets}.
	 * @param ctx the parse tree
	 */
	void enterBrackets(LambdaParser.BracketsContext ctx);
	/**
	 * Exit a parse tree produced by {@link LambdaParser#brackets}.
	 * @param ctx the parse tree
	 */
	void exitBrackets(LambdaParser.BracketsContext ctx);
}