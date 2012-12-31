#!/usr/bin/perl

# Brise c/b slike i slike koje nisu frontalne iz feretove baze
# ako u direktoriju nema niti jedne korisne slike, obrise i njega

use strict;
use warnings;

my $dir = 'images';

open(GRAYSCALE, "../doc/grayscale.out") or die $!;
my @grayscale_slike = <GRAYSCALE>;
chomp(@grayscale_slike);
close(GRAYSCALE);

opendir(DIR, $dir) or die $!;
while (my $sample = readdir(DIR)) {
	next unless (-d "$dir/$sample");
	
	opendir(SAMPLE, "$dir/$sample") or die $!;
	my $barem_jedna = 0;
	while (my $picture = readdir(SAMPLE)) {
		next unless (-f "$dir/$sample/$picture");
		my $full_name =  "data/images/$sample/$picture";
		my $info = ((split("ppm", $picture))[0])."txt";
		print $full_name." ";
		if (grep {$_ eq $full_name} @grayscale_slike) {
			print " - brisem sliku i $info jer c/b\n";
			`rm $dir/$sample/$picture`;
			`rm ground_truths/name_value/$sample/$info`;
			next;
		} elsif (substr( (split("_", $picture))[2], 0, 1) ne "f") {
			print " - brisem sliku i $info jer nije frontalno\n";
			`rm $dir/$sample/$picture`;
			`rm ground_truths/name_value/$sample/$info`;
		} else {
			$barem_jedna = 1;
			print "\n";
		}
	}
	if (!$barem_jedna) {
		print "brisem direktoriji $dir/$sample jer nema niti jedne korisne slike\n";
		`rm -rf $dir/$sample`;
		`rm -rf ground_truths/name_value/$sample`;
	}

	close(SAMPLE);
}

closedir(DIR);
