<?php

class SomeTests extends PHPUnit_Framework_TestCase {

	public function testSomeVeryImportantStuff_ShouldBeTrue() {
		$this->assertEquals(true, true);
	}

	public function testSomeEvenMoreImportantThings_ShouldBeFalse() {
		$importantThingOne = "one";
		$this->assertEquals($importantThingOne, "two");
	}


}

?>