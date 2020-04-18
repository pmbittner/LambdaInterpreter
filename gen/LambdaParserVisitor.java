// Generated from C:/Users/Paul Bittner/Documents/Projects/LambdaInterpreter/LambdaInterpreter/res/Grammar\LambdaParser.g4 by ANTLR 4.8
import org.antlr.v4.runtime.tree.ParseTreeVisitor;

/**
 * This interface defines a complete generic visitor for a parse tree produced
 * by {@link LambdaParser}.
 *
 * @param <T> The return type of the visit operation. Use {@link Void} for
 * operations with no return type.
 */
public interface LambdaParserVisitor<T> extends ParseTreeVisitor<T> {
	/**
	 * Visit a parse tree produced by {@link LambdaParser#lambdaTerm}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLambdaTerm(LambdaParser.LambdaTermContext ctx);
	/**
	 * Visit a parse tree produced by {@link LambdaParser#abstraction}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAbstraction(LambdaParser.AbstractionContext ctx);
	/**
	 * Visit a parse tree produced by {@link LambdaParser#variable}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitVariable(LambdaParser.VariableContext ctx);
	/**
	 * Visit a parse tree produced by {@link LambdaParser#brackets}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBrackets(LambdaParser.BracketsContext ctx);
}